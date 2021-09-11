using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.Models
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime DateCreated { get; set; }
        public string Text { get; set; }

        public Guid ReviewId { get; set; }
        public virtual Review Review { get; set; }
    }
}
