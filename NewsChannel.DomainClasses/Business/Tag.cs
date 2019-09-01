using System.Collections.Generic;
namespace NewsChannel.DomainClasses.Business
{
    public class Tag
    {
        public int Id { get; set; }
        public int TagName { get; set; }
        public virtual ICollection<NewsTag> NewsTags { get; set; }
    }
}