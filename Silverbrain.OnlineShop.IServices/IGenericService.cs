using Silverbrain.OnlineShop.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IGenericService<TEntity, TKey>
    where TEntity : class
    {
        Task<TransactionResult> SaveChangesAsync();
        Task<TransactionResult> AddAsync(TEntity entity);
        IQueryable<TEntity> ReadAll();
        Task<TEntity> FindAsync(TKey Id);
        TransactionResult Update(TEntity entity);
        TransactionResult Remove(TKey Id);

    }
}