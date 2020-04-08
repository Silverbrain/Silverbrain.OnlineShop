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
        public async Task<TransactionResult> AddAsync(TEntity entity)
        {
            try
            {
                await entities.AddAsync(entity);
                return new TransactionResult
                {
                    IsSuccess=true,
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess=false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }
        public async Task<TransactionResult> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return new TransactionResult
                {
                    IsSuccess=true,
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess=false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

        public IQueryable<TEntity> ReadAll() =>
            entities.AsQueryable();

        public async Task<TEntity> FindAsync(TKey Id) =>
            await entities.FindAsync(Id);

        public TransactionResult Update(TEntity entity)
        {
            try
            {
                entities.Update(entity);
                return new TransactionResult
                {
                    IsSuccess= true,
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess = false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }
        public TransactionResult Remove(TKey Id)
        {
            try
            {
                entities.Remove(entities.Find(Id));
                return new TransactionResult
                {
                    IsSuccess = true,
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess = false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

    }
}