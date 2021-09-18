using ReviewAppMVC2.BLL.VMs.MediaFileVM;
using ReviewAppMVC2.BLL.VMs.ReviewVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.BLL.VMs.ProductVM
{
    public class ProductData
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<ReviewData> Reviews { get; set; } = new List<ReviewData>();

        public List<MediaFileCreate> MediaFiles { get; set; } = new List<MediaFileCreate>();
    }
}
