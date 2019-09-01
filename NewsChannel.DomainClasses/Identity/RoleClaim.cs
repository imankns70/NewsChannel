using Microsoft.AspNetCore.Identity;

namespace NewsChannel.DomainClasses.Identity
{
    public class RoleClaim:IdentityRoleClaim<string>
    {
        public virtual Role Role { get; set; }
    }
}