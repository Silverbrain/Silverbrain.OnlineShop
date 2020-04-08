using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IBrandService:IGenericService<Brand,int>
    {
        Task<BrandViewModel> GetByIdAsync(int Id);
        public Task<TransactionResult> CreateAsync(BrandViewModel model);

        public Task<TransactionResult> UpdateAsync(BrandViewModel model);
        Task<TransactionResult> DeleteAsync(int id);
        public new IQueryable<Brand> ReadAll();
    }
}