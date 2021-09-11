using ReviewAppMVC.BLL.VMs.MediaFileVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.BLL.VMs.ReviewVMs
{
    public class ReviewCreate
    {
        public Guid UserId { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public Guid ProductId { get; set; }
        public List<MediaFileCreate> MediaFiles { get; set; }
    }
}
