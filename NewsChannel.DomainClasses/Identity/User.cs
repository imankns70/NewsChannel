using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using NewsChannel.Common.Enums;
using NewsChannel.DomainClasses.Business;
 
namespace NewsChannel.DomainClasses.Identity
{
    public class User:IdentityUser
    {
     public string FirstName { get; set; }   
     public string LastName { get; set; }   
     public DateTime BirthDate { get; set; }   
     public string Image { get; set; }   
     public DateTime RegisterDateTime { get; set; }   
     public bool IsActive { get; set; }   
     public GenderType Gender { get; set; } 
     public virtual ICollection<News> News{get;set;}
     public virtual ICollection<BookMark> BookMarks { get; set; }
     public virtual ICollection<UserRole> Roles { get; set; }
     public virtual ICollection<UserClaim> Claims { get; set; }
    }
}