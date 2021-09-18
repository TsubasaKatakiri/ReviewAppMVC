using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;

        private IRepository<Product> _products;
        private IRepository<Review> _reviews;
        private IRepository<Comment> _comments;
        private IRepository<MediaFile> _mediaFiles;

        private bool _disposed = false;

        public UnitOfWork(AppDBContext db)
        {
            _db = db;
        }

        public IRepository<Product> Products => _products ??= new Repository<Product>(_db);
        public IRepository<Review> Reviews => _reviews ??= new Repository<Review>(_db);
        public IRepository<Comment> Comments => _comments ??= new Repository<Comment>(_db);
        public IRepository<MediaFile> MediaFiles => _mediaFiles ??= new Repository<MediaFile>(_db);

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }
            if (disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
