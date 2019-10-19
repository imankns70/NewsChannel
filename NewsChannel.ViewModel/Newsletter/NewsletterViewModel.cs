using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NewsChannel.ViewModel.Newsletter
{
    public class NewsletterViewModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [Display(Name = "ایمیل")]
        [JsonProperty("ایمیل")]
        [Required(ErrorMessage ="وارد نمودن {0} الزامی است."),EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمی باشد.")]
        public string Email { get; set; }

        [JsonProperty("ردیف")]
        public int Row { get; set; }

        [JsonProperty("تاریخ عضویت")]
        public string PersianRegisterDateTime { get; set; }

        [JsonIgnore]
        public DateTime? RegisterDateTime { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
    }
}
