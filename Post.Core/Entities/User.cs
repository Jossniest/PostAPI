using System;
using System.Collections.Generic;

namespace Post.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Publication> Publications { get; set; }
    }
}
