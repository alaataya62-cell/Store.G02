using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.Domain.Contracts
{
    public interface IUnitOfWork 
    {
      IGenaricRepository <IKey, TEntity> GetRepository<IKey, TEntity>() where TEntity : BaseEntity<IKey>;
      Task<int> SaveChangesAsync();
    }
}
