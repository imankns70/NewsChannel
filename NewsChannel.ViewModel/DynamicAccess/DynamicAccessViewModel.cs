using System.Collections.Generic;
using NewsChannel.DomainClasses.Identity;

namespace NewsChannel.ViewModel.DynamicAccess
{
    public class DynamicAccessIndexViewModel
    {
        public string ActionIds { set; get; }
        public int UserId { set; get; }
        public User UserIncludeUserClaims { set; get; }
        public ICollection<ControllerViewModel> SecuredControllerActions { set; get; }
    }
}
