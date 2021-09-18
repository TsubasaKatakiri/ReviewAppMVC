using ReviewAppMVC2.BLL.VMs.CommentVM;
using ReviewAppMVC2.BLL.VMs.MediaFileVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.BLL.VMs.ReviewVM
{
    public class ReviewData
    {
        public Guid ReviewId { get; set; }
        public Guid? ProductId { get; set; }

        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public string ProductName { get; set; }

        public List<CommentData> Comments { get; set; } = new List<CommentData>();

        public List<MediaFileCreate> MediaFiles { get; set; } = new List<MediaFileCreate>();
    }
}
