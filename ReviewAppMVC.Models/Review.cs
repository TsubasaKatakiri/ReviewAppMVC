using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.Models
{
    public class Review : MediaEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public DateTime DateCreated { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }


        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
