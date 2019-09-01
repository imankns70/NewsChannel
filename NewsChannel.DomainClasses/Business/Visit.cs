using System;
namespace NewsChannel.DomainClasses.Business {
    public class Visit {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string IpAddress { get; set; }
        public DateTime LastVisitedDateTime { get; set; }
        public int NumberOfVisit { get; set; }
        public virtual News News { get; set; }

    }
}