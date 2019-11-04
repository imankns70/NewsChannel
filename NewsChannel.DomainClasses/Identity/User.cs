using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewsChannel.DomainClasses.Business;

namespace NewsChannel.DomainClasses.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public DateTime? RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
        public GenderType Gender { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<BookMark> BookMarks { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
    }

    public enum GenderType
    {
        [Display(Name = "مرد")]
        Male = 1,

        [Display(Name = "زن")]
        Female = 2
    }
}