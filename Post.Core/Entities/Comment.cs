using System;

namespace Post.Core.Entities
{
    public class Comment : BaseEntity
    {
        public int PublicationId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public Publication Publications { get; set; }
        public User User { get; set; }
    }
}
