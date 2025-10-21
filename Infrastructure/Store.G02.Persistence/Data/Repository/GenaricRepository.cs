using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.G02.Domain;
using Store.G02.Domain.Contracts;
using Store.G02.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.Persistence.Data.Repository
{
    internal class GenaricRepository<IKey, TEntity>(StoreDbContext _context) : IGenaricRepository<IKey, TEntity> where TEntity : BaseEntity<IKey>
    {
        public async Task AddAsync(TEntity entity)
        {
          await  _context.Set<TEntity>().AddAsync(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool ChageTracker = false)
        {
            return ChageTracker ?
              await _context.Set<TEntity>().ToListAsync()
               : await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetAsync(IKey key)
        {
            return _context.Set<TEntity>().FindAsync(key).AsTask();
        }

        public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
