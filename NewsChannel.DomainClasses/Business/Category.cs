using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsChannel.DomainClasses.Business {
    public class Category {


        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("category")]
        public int? ParentCategoryId { get; set; }
        public string Url { get; set; }
        public virtual ICollection<NewsCategory> NewsCategories { get; set; }
        public virtual Category category { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}