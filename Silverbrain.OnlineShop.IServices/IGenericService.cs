using Silverbrain.OnlineShop.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public interface IGenericService<TEntity,TKey>
    where TEntity : class
    {
        IQueryable<TEntity> ReadAll();

        Task<TEntity> ReadAsync(TKey Id);

        Task CreatAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<TransactionResult> DeleteAsync(TKey Id);
    }
}