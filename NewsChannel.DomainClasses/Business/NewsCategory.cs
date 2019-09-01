namespace NewsChannel.DomainClasses.Business {
    public class NewsCategory {
        public int NewsId { get; set; }
        public int CategoryId { get; set; }
        public virtual News News { get; set; }
        public virtual Category Category { get; set; }

    }
}