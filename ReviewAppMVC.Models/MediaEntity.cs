using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC.Models
{
    public class MediaEntity : BaseEntity
    {
        public virtual List<MediaFile> Files { get; set; } = new List<MediaFile>();
    }
}
