using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.BLL.VMs.CommentVMs
{
    public class CommentData
    {
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public string ProductName { get; set; }
        public Guid ReviewId { get; set; }
    }
}
