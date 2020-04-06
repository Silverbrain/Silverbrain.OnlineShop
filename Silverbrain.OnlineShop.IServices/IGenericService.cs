using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public interface IGenericService<TEntity>
    where TEntity : class
    {
        IQueryable<TEntity> ReadAll();

        Task<TEntity> ReadAsync(string Id);

        Task<TEntity> ReadAsync(int Id);

        Task CreatAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(string Id);

        Task DeleteAsync(int Id);
    }
}