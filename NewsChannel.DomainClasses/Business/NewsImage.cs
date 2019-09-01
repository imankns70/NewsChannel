namespace NewsChannel.DomainClasses.Business
{
    public class NewsImage
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string ImageName { get; set; }
        public virtual News News { get; set; }


    }
}