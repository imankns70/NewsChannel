using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsChannel.DomainClasses.Business
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<NewsTag> NewsTags { get; set; }
    }
}