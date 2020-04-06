using Silverbrain.OnlineShop.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IGenericService<TEntity,TKey>
    where TEntity : class
    {
        IQueryable<TEntity> ReadAll();

        Task<TEntity> ReadAsync(TKey Id);

        Task<TransactionResult> CreatAsync(TEntity entity);

        Task<TransactionResult> UpdateAsync(TEntity entity);

        Task<TransactionResult> DeleteAsync(TKey Id);
    }
}