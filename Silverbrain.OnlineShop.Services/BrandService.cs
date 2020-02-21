using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Brand brand) =>
            await _repository.CreatAsync(brand);

        public async Task DeleteAsync(int Id) =>
            await _repository.DeleteAsync(Id);

        public async Task<IList<Brand>> ReadAllAsync() =>
            await _repository.ReadAllAsync();

        public async Task<Brand> ReadAsync(int Id) =>
            await _repository.ReadAsync(Id);

        public async Task UpdateAsync(Brand brand) =>
            await _repository.UpdateAsync(brand);
    }
}
