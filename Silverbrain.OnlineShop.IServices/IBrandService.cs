using Microsoft.AspNetCore.Mvc.ModelBinding;
using Silverbrain.OnlineShop.Common;
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
        public Task<TransactionResult> CreateAsync(BrandViewModel model);
        public Task<TransactionResult> UpdateAsync(BrandViewModel model);
        public Task<TransactionResult> DeleteAsync(int Id);
        public Task<BrandViewModel> ReadAsync(int Id);
        public IQueryable<Brand> ReadAll();
    }
}
