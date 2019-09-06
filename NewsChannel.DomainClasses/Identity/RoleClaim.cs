using Microsoft.AspNetCore.Identity;

namespace NewsChannel.DomainClasses.Identity
{
    public class RoleClaim:IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}