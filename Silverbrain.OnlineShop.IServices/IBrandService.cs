using Silverbrain.OnlineShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IBrandService
    {
        public Task CreateAsync(Brand brand);
        public Task UpdateAsync(Brand brand);
        public Task DeleteAsync(int Id);
        public Task<Brand> ReadAsync(int Id);
        public Task<IList<Brand>> ReadAllAsync();
    }
}
