using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewAppMVC2.Models
{
    public class Review : MediaEntity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public virtual User User { get; set; }

        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        public DateTime DateCreated { get; set; }
        [Range(0, 5)]
        public int Score { get; set; }
        public string Text { get; set; }

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
