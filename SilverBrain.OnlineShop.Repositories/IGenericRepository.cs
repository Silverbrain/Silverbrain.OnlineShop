using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Repositories
{
    interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IQueryable<TEntity>> ReadAllAsync();
        Task<TEntity> ReadByIdAsync<TIdType>(TIdType Id);
        Task CreatAsync(TEntity entity);
        Task UpdateAsync<TIdType>(TIdType id, TEntity entity);

    }
}
