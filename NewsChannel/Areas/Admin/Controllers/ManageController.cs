using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsChannel.Common;
using NewsChannel.DomainClasses.Identity;
using NewsChannel.Service.Contracts;
using NewsChannel.ViewModel.Manage;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class ManageController : BaseController
    {
        private readonly IApplicationRoleManager _roleManager;
        private readonly IApplicationUserManager _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<ManageController> _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public ManageController(IApplicationRoleManager roleManager, IApplicationUserManager userManager, SignInManager<User> signInManager, ILogger<ManageController> logger, IHttpContextAccessor accessor, IMapper mapper, IHostingEnvironment env)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _accessor = accessor;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public IActionResult SignIn(string ReturnUrl = null)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByNameAsync(ViewModel.UserName);
                if (User != null)
                {
                    if (User.IsActive)
                    {
                        var result = await _signInManager.PasswordSignInAsync(ViewModel.UserName, ViewModel.Password, ViewModel.RememberMe, true);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                        else if (result.IsLockedOut)
                            ModelState.AddModelError(string.Empty, "حساب کاربری شما به مدت 20 دقیقه به دلیل تلاش های ناموفق قفل شد.");

                        else if (result.RequiresTwoFactor)
                            return RedirectToAction("SendCode", new { RememberMe = ViewModel.RememberMe });

                        else
                        {
                            ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور شما صحیح نمی باشد.");
                            _logger.LogWarning($"The user attempts to login with the IP address({_accessor.HttpContext?.Connection?.RemoteIpAddress.ToString()}) and username ({ViewModel.UserName}) and password ({ViewModel.Password}).");
                        }
                    }
                    else
                        ModelState.AddModelError(string.Empty, "حساب کابری شما غیرفعال است.");
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور شما صحیح نمی باشد.");
                    _logger.LogWarning($"The user attempts to login with the IP address({_accessor.HttpContext?.Connection?.RemoteIpAddress.ToString()}) and username ({ViewModel.UserName}) and password ({ViewModel.Password}).");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Manage", new { area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel ViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var changePassResult = await _userManager.ChangePasswordAsync(user, ViewModel.OldPassword, ViewModel.NewPassword);
                if (changePassResult.Succeeded)
                    ViewBag.Alert = "کلمه عبور شما با موفقیت تغییر یافت.";

                else
                    ModelState.AddErrorsFromResult(changePassResult);
            }

            return View(ViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profileViewModel = new ProfileViewModel();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return NotFound();
            else
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                    return NotFound();
                else
                {
                    profileViewModel.Id = user.Id;
                    profileViewModel.Email = user.Email;
                    profileViewModel.FirstName = user.FirstName;
                    profileViewModel.LastName = user.LastName;
                    profileViewModel.Image = user.Image;
                    profileViewModel.UserName = user.UserName;
                    profileViewModel.Gender = user.Gender;
                    profileViewModel.PhoneNumber = user.PhoneNumber;
                    profileViewModel.PersianBirthDate = user.BirthDate.ConvertMiladiToShamsi("yyyy/MM/dd");
                }
            }

            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel viewModel)
        {
            if (viewModel.Id == null)
                return RedirectToAction("Index", "Dashboard");

            var user = await _userManager.FindByIdAsync(viewModel.Id.ToString());
            if (user == null)
                return NotFound();

            if (viewModel.ImageFile != null)
            {
                viewModel.Image = _userManager.CheckAvatarFileName(viewModel.ImageFile.FileName);

                FileExtensions.UploadFileResult fileResult = await viewModel.ImageFile.UploadFileAsync($"{_env.WebRootPath}/avatars/{viewModel.Image}");
                if (fileResult.IsSuccess == false)
                {
                    ModelState.AddModelError(string.Empty, InvalidImage);
                    return View(viewModel);
                }
                else
                    FileExtensions.DeleteFile($"{_env.WebRootPath}/avatars/{user.Image}");
            }

            else
                viewModel.Image = user.Image;

            user.UserName = viewModel.UserName;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.BirthDate = viewModel.PersianBirthDate.ConvertShamsiToMiladi();
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.Image = viewModel.Image;
            if (viewModel.Gender != null) user.Gender = viewModel.Gender.Value;
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                ViewBag.Alert = EditSuccess;
            else
                ModelState.AddErrorsFromResult(result);


            return View(viewModel);

        }
    }
}