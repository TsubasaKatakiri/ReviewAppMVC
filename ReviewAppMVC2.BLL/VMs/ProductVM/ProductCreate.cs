using ReviewAppMVC2.BLL.VMs.MediaFileVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.BLL.VMs.ProductVM
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<MediaFileCreate> MediaFiles { get; set; }
    }
}
