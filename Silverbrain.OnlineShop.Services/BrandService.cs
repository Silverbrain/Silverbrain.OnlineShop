using AutoMapper;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Repositories;
using Silverbrain.OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BrandViewModel model)
        {
            var brand = _mapper.Map<Brand>(model);
            await _repository.CreatAsync(brand);
        }

        public async Task DeleteAsync(int Id) =>
            await _repository.DeleteAsync(Id);

        public IQueryable<Brand> ReadAll() =>
            _repository.ReadAll();

        public async Task<BrandViewModel> ReadAsync(int Id)
        {
            var brand = await _repository.ReadAsync(Id);
            return _mapper.Map<BrandViewModel>(brand);
        }

        public async Task UpdateAsync(BrandViewModel model)
        {
            var brand = _mapper.Map<Brand>(model);
            await _repository.UpdateAsync(brand);
        }
    }
}
