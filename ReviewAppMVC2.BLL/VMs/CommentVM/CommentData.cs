using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.BLL.VMs.CommentVM
{
    public class CommentData
    {
        public Guid? ReviewId { get; set; }
        public Guid? CommentId { get; set; }

        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public string ProductName { get; set; }
    }
}
