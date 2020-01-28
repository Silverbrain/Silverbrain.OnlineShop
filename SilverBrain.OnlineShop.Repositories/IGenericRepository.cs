using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> ReadAllAsync();
        Task<TEntity> ReadByIdAsync<TIdType>(TIdType Id);
        Task CreatAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync<TIdType>(TIdType id);
    }
}
