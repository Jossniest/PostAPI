﻿using System;
using System.Collections.Generic;

namespace Post.Core.Entities
{
    public class Publication : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
