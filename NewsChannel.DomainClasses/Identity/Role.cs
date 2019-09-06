using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NewsChannel.DomainClasses.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role(string name) : base(name) { }
        public Role(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }

     public virtual ICollection<UserRole> Users { get; set; }
     public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}