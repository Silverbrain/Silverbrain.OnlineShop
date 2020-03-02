using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IBrandService
    {
        public Task CreateAsync(BrandViewModel model);
        public Task UpdateAsync(BrandViewModel model);
        public Task DeleteAsync(int Id);
        public Task<BrandViewModel> ReadAsync(int Id);
        public IQueryable<Brand> ReadAll();
    }
}
