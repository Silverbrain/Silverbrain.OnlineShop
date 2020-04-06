using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.DataLayer;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity>
    where TEntity : class
    {
        private readonly OnlineShopDbContext _dbContext;
        private DbSet<TEntity> entities;

        public GenericService(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }

        public async Task CreatAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> ReadAll() =>
            entities.AsQueryable();

        public async Task<TEntity> ReadAsync(string Id) =>
            await entities.FindAsync(Id);

        public async Task<TEntity> ReadAsync(int Id) =>
            await entities.FindAsync(Id);

        public async Task UpdateAsync(TEntity entity)
        {
            entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            entities.Remove(entities.Find(Id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            entities.Remove(entities.Find(Id));
            await _dbContext.SaveChangesAsync();
        }
    }
}