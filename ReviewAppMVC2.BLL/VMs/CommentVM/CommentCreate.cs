using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.BLL.VMs.CommentVM
{
    public class CommentCreate
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public Guid? ProductId { get; set; }

        public string Text { get; set; }
        public Guid? ReviewId { get; set; }
    }
}
