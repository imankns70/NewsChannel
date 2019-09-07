using System;
using System.ComponentModel.DataAnnotations;

namespace NewsChannel.DomainClasses.Business
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Poster { get; set; }
        public DateTime? PublishDateTime { get; set; }
    }
}
