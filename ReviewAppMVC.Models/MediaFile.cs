using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.Models
{
    public class MediaFile : BaseEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid MediaEntityId { get; set; }
        public virtual MediaEntity MediaEntity { get; set; }
    }
}
