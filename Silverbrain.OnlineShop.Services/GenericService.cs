using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class GenericService<TEntity, TKey> : IGenericService<TEntity, TKey>
    where TEntity : class

    {
        protected readonly OnlineShopDbContext _dbContext;
        protected readonly DbSet<TEntity> entities;

        public GenericService(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
            entities = _dbContext.Set<TEntity>();
        }

        public async Task<TransactionResult> CreatAsync(TEntity entity)
        {
            try
            {
                await entities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return new TransactionResult
                {
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

        public IQueryable<TEntity> ReadAll() =>
            entities.AsQueryable();

        public async Task<TEntity> ReadAsync(TKey Id) =>
            await entities.FindAsync(Id);

        public async Task<TransactionResult> UpdateAsync(TEntity entity)
        {
            try
            {
                entities.Update(entity);
                await _dbContext.SaveChangesAsync();
                return new TransactionResult
                {
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

        public async Task<TransactionResult> DeleteAsync(TKey Id)
        {
            try
            {
                entities.Remove(entities.Find(Id));
                await _dbContext.SaveChangesAsync();
                return new TransactionResult
                {
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }
    }
}