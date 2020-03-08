using Silverbrain.OnlineShop.Common;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Repositories.Brand
{
    public interface IBrandRepository
    {
        Task<TransactionResult> CreateValidationAsync(Entities.Models.Brand brand);
        Task<TransactionResult> UpdateValidationAsync(Entities.Models.Brand brand);
    }
}