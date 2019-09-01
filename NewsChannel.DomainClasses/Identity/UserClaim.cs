using Microsoft.AspNetCore.Identity;

namespace NewsChannel.DomainClasses.Identity {
    public class UserClaim : IdentityUserClaim<string>
     {
        public virtual User User { get; set; }
    }
}