using System;
using System.Collections.Generic;

namespace NewsChannel.DomainClasses.Business {
    public class Comment {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? PostageDateTime { get; set; }
        public bool IsConfirm { get; set; }
        public int ParentCommentId { get; set; }
        public virtual News News { get; set; }
        public virtual Comment comment { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}