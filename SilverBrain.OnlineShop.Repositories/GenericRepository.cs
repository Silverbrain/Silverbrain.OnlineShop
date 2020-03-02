using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silverbrain.OnlineShop.Entities;

namespace Silverbrain.OnlineShop.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly OnlineShopDbContext _dbContext;
        private DbSet<TEntity> entities;

        public GenericRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }

        public async Task CreatAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> ReadAllAsync() =>
            await entities.ToListAsync();

        public async Task<TEntity> ReadAsync(string Id) =>
            await entities.FindAsync(Id);

        public async Task<TEntity> ReadAsync(int Id) =>
            await entities.FindAsync(Id);

        public async Task UpdateAsync(TEntity entity)
        {
                entities.Update(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {

            }
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
