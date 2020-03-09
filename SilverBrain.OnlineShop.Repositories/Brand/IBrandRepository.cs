using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.ViewModels;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Repositories.Brand
{
    public interface IBrandRepository
    {
        Task<TransactionResult> CreateValidationAsync(BrandViewModel brand);
        Task<TransactionResult> UpdateValidationAsync(BrandViewModel brand);
    }
}