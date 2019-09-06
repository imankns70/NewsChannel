using NewsChannel.DomainClasses.Identity;

namespace NewsChannel.DomainClasses.Business
{
    public class BookMark
    {
        public int NewsId { get; set; }
        public int UserId { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}