using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<TEntity>> ReadAllAsync() =>
            await entities.ToListAsync();

        public async Task<TEntity> ReadByIdAsync<TIdType>(TIdType Id) =>
            await entities.FindAsync(Id);

        public async Task UpdateAsync(TEntity entity)
        {
            entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<TIdType>(TIdType id)
        {
            entities.Remove(entities.Find(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
