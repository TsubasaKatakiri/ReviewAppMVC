using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.BLL.VMs.MediaFileVMs
{
    public class MediaFileCreate
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? MediaEntityId { get; set; }
    }
}
