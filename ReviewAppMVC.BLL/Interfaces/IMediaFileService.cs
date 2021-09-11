using ReviewAppMVC.BLL.VMs.MediaFileVMs;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Interfaces
{
    public interface IMediaFileService
    {
        Task<Guid> CreateMediaFileAsync(MediaFileCreate mediaFile);
        List<MediaFileCreate> FindMediaFile(Func<MediaFile, bool> expression);
    }
}
