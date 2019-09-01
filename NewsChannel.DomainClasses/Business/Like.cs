namespace NewsChannel.DomainClasses.Business {
    public class Like {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string IpAddress { get; set; }
        public bool IsLike { get; set; }
        public virtual News News { get; set; }

    }
}