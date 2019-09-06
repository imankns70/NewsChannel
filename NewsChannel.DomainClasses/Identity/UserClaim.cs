using Microsoft.AspNetCore.Identity;

namespace NewsChannel.DomainClasses.Identity {
    public class UserClaim : IdentityUserClaim<int>
     {
        public virtual User User { get; set; }
    }
}