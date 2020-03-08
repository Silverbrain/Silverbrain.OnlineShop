using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Resources;
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

        public async Task<TransactionResult> CreateValidationAsync(Entities.Models.Brand brand)
        {
            var isUnique = await _dbContext.Brands.FirstOrDefaultAsync(b => b.Title == brand.Title) != null ? true : false;

            return isUnique
                ? new TransactionResult { Type = ResultType.Success.ToString(), Message = Messages.SuccessfulTransactionMessage }
                : new TransactionResult { Type = ResultType.Error.ToString(), Message = Messages.ItemExistsErrorMessage };
        }

        public async Task<TransactionResult> UpdateValidationAsync(Entities.Models.Brand brand)
        {
            throw new System.NotImplementedException();
        }
    }
}