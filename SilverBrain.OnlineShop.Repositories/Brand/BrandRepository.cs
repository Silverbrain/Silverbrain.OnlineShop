using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Resources;
using System;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Repositories.Brand
{
    public class BrandRepository : IBrandRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public BrandRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsUnique(string title) =>
            await _dbContext.Brands.FirstOrDefaultAsync(b => b.Title.Equals(title)) == null ? true : false;

        public async Task<TransactionResult> CreateValidationAsync(Entities.Models.Brand brand) =>
            await IsUnique(brand.Title)
                ? new TransactionResult { Type = ResultType.Success.ToString(), Message = Messages.SuccessfulTransactionMessage }
                : new TransactionResult { Type = ResultType.Error.ToString(), Message = Messages.ItemExistsErrorMessage };

        public async Task<TransactionResult> UpdateValidationAsync(Entities.Models.Brand brand) =>
            await IsUnique(brand.Title)
                ? new TransactionResult { Type = ResultType.Success.ToString(), Message = Messages.SuccessfulTransactionMessage }
                : new TransactionResult { Type = ResultType.Error.ToString(), Message = Messages.ItemExistsErrorMessage };
    }
}