using ReviewAppMVC2.BLL.VMs.MediaFileVM;
using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.BLL.Interfaces
{
    public interface IMediaFileService
    {
        Task<Guid> CreateMediaFileAsync(MediaFileCreate mediaFile);
        List<MediaFileCreate> FindMediaFile(Func<MediaFile, bool> expression);
    }
}
