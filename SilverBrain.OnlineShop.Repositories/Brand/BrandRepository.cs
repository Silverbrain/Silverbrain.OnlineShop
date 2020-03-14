using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
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

        public async Task<bool> IsUnique(BrandViewModel brand)
           => !await _dbContext.Brands.AsNoTracking().AnyAsync(b => b.Id != brand.Id &&  b.Title.Equals(brand.Title));

        public async Task<bool> CreateValidationAsync(BrandViewModel brand) =>
            await IsUnique(brand);

        public async Task<bool> UpdateValidationAsync(BrandViewModel brand)
        => await IsUnique(brand);
    }
}