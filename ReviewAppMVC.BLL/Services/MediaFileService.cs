using ReviewAppMVC.BLL.Interfaces;
using ReviewAppMVC.BLL.VMs.MediaFileVMs;
using ReviewAppMVC.DAL.Patterns;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Services
{
    public class MediaFileService : IMediaFileService
    {
        public MediaFileService(IUnitOfWork db)
        {
            _db = db;
        }

        private readonly IUnitOfWork _db;

        public async Task<Guid> CreateMediaFileAsync(MediaFileCreate _mediaFile)
        {
            try
            {
                var mediaFile = new MediaFile()
                {
                    Name = _mediaFile.Name,
                    Extension = _mediaFile.Extension,
                    Path = _mediaFile.Path,
                    DateCreated = DateTime.Now,
                    MediaEntityId = _mediaFile.MediaEntityId.Value
                };
                mediaFile = await _db.MediaFiles.CreateAsync(mediaFile);
                return mediaFile.Id;

            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public List<MediaFileCreate> FindMediaFile(Func<MediaFile, bool> expression)
        {
            try
            {
                List<MediaFile> mediaFiles;
                if (expression == null)
                {
                    mediaFiles = _db.MediaFiles.GetAll().ToList();
                }
                else
                {
                    mediaFiles = _db.MediaFiles.GetAll().Where(expression).ToList();
                }
                return mediaFiles.Select(f =>
                {
                    return new MediaFileCreate()
                    {
                        Name = f.Name,
                        Extension = f.Extension,
                        Path = f.Path,
                        DateCreated = f.DateCreated,
                        MediaEntityId = f.MediaEntityId
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
