using System;
using System.Collections.Generic;
using NewsChannel.DomainClasses.Identity;

namespace NewsChannel.DomainClasses.Business {
    public class News {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDateTime { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string ImageName { get; set; }
        public bool IsPublish { get; set; }
        public bool IsInternal { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<NewsCategory> NewsCategories { get; set; }
        public virtual ICollection<BookMark> BookMarks { get; set; }
        public virtual ICollection<NewsTag> NewsTags { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<NewsImage> NewsImages { get; set; }

    }
}