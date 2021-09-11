using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.BLL.VMs.CommentVMs
{
    public class CommentCreate
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public Guid ReviewId { get; set; }
    }
}
