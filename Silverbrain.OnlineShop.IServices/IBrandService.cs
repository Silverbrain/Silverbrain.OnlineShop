using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.Services;
using Silverbrain.OnlineShop.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IBrandService:IGenericService<Brand,int>
    {
        public Task<TransactionResult> CreateAsync(BrandViewModel model);

        public Task<TransactionResult> UpdateAsync(BrandViewModel model);
        public Task<BrandViewModel> ReadAsync(int Id);
        public IQueryable<Brand> ReadAll();
    }
}