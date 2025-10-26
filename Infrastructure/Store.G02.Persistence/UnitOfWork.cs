using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using Store.G02.Domain;
using Store.G02.Domain.Contracts;
using Store.G02.Persistence.Data.Contexts;
using Store.G02.Persistence.Data.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.Persistence;
public class UnitOfWork(StoreDbContext _context) : IUnitOfWork
{
    //private Dictionary<string, object> _repositories = new Dictionary<string , object>();
    private ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string , object>();

    public IGenaricRepository<IKey, TEntity> GetRepository<IKey, TEntity>() where TEntity : BaseEntity<IKey>
    {
        //var type = typeof(TEntity).Name;
        // if (!_repositories.ContainsKey(type))
        // {

        //     var repository = new GenaricRepository<IKey ,TEntity>(_context);
        //     _repositories.Add(type, repository);
        // }
        // return (IGenaricRepository<IKey, TEntity>)_repositories[type];
        return (IGenaricRepository<IKey, TEntity>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenaricRepository<IKey, TEntity>(_context));


    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
 