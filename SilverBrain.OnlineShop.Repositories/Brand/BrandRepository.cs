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

        public async Task<bool> IsUnique(string title)
        {
            var result = await _dbContext.Brands.AsNoTracking().AnyAsync(b => b.Title.Equals(title));
            return !result;
        }

        public async Task<bool> CreateValidationAsync(BrandViewModel brand) =>
            await IsUnique(brand.Title) ? true : false;

        public async Task<bool> UpdateValidationAsync(BrandViewModel brand)
        {
            if (await _dbContext.Brands.AnyAsync(b => b.Id == brand.Id && b.Title == brand.Title))
                return true;

            return await IsUnique(brand.Title) ? true : false;
        }
    }
}