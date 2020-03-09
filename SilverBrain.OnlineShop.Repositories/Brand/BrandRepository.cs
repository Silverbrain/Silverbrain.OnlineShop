using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
using System.Linq;
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

        public async Task<bool> IsUnique(string title)
        {
            //Entities.Models.Brand brand = null;
            //await _dbContext.Brands.AsNoTracking().ForEachAsync(b =>
            //{
            //    if (b.Title.Equals(title))
            //    {
            //        brand = b;
            //        return;
            //    }
            //});
            var brand = await _dbContext.Brands.AsNoTracking().FirstOrDefaultAsync(b => EF.Functions.Like(b.Title,$"%{title}%"));
            var result = brand == null ? true : false;
            return result;
        }

        public async Task<TransactionResult> CreateValidationAsync(BrandViewModel brand) =>
            await IsUnique(brand.Title)
                ? new TransactionResult { Type = ResultType.Success.ToString(), Message = Messages.SuccessfulTransactionMessage }
                : new TransactionResult { Type = ResultType.Error.ToString(), Message = Messages.ItemExistsErrorMessage };

        public async Task<TransactionResult> UpdateValidationAsync(BrandViewModel brand) =>
            await IsUnique(brand.Title)
                ? new TransactionResult { Type = ResultType.Success.ToString(), Message = Messages.SuccessfulTransactionMessage }
                : new TransactionResult { Type = ResultType.Error.ToString(), Message = Messages.ItemExistsErrorMessage };
    }
}