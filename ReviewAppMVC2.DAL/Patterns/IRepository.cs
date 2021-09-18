using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.DAL.Patterns
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task DeleteAsync(int id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        Task Save();
    }
}
