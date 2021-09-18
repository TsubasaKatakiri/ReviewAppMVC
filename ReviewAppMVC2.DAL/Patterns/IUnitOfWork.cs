using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.DAL.Patterns
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Comment> Comments { get; }
        IRepository<MediaFile> MediaFiles { get; }

        Task SaveAsync();
    }
}
