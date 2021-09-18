using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.DAL.Patterns
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDBContext _db;

        public Repository(AppDBContext db)
        {
            _db = db;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity item)
        {
            try
            {
                var newEntity = await _db.Set<TEntity>().AddAsync(item);
                await Save();
                return newEntity.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _db.Set<TEntity>().Remove(entity);
            await Save();
        }

        public virtual System.Linq.IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity item)
        {
            _db.Set<TEntity>().Update(item);
            await Save();
            return item;
        }
    }
}
