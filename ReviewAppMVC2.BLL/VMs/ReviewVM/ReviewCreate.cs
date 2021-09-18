using ReviewAppMVC2.BLL.VMs.MediaFileVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.BLL.VMs.ReviewVM
{
    public class ReviewCreate
    {
        private Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public Guid? ProductId { get; set; }

        public List<MediaFileCreate> MediaFiles { get; set; }
    }
}
