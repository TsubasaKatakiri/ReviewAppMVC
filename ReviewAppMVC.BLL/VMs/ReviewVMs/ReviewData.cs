using ReviewAppMVC.BLL.VMs.CommentVMs;
using ReviewAppMVC.BLL.VMs.MediaFileVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.BLL.VMs.ReviewVMs
{
    public class ReviewData
    {
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public string ProductName { get; set; }
        public List<MediaFileCreate> MediaFiles { get; set; } = new List<MediaFileCreate>();
        public List<CommentData> Comments { get; set; } = new List<CommentData>();
    }
}
