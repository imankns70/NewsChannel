using System;
namespace NewsChannel.DomainClasses.Business
{
    public class NewsLetter
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}