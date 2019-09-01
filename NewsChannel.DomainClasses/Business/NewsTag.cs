namespace NewsChannel.DomainClasses.Business {
    public class NewsTag {
        public int NewsId { get; set; }
        public int TagId { get; set; }
        public virtual News News { get; set; }
        public virtual Tag Tag { get; set; }

    }
}