using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.Domain.Contracts
{
  public interface IGenaricRepository<IKey, IEntity> where IEntity : BaseEntity<IKey>
    {
        Task<IEnumerable<IEntity>> GetAllAsync();
        Task<IEntity?> GetAsync(IKey key);
        Task AddAsync(IEntity entity);
        void UpdateAsync(IEntity entity);
        void DeleteAsync(IEntity entity);
    }
}
