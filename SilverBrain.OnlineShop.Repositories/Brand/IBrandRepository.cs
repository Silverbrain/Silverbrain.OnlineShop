using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.ViewModels;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Repositories.Brand
{
    public interface IBrandRepository
    {
        Task<bool> CreateValidationAsync(BrandViewModel brand);
        Task<bool> UpdateValidationAsync(BrandViewModel brand);
    }
}