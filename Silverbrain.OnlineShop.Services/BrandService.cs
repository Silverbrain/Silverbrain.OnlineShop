﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericService<Brand> _generic;
        private readonly OnlineShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public BrandService(IGenericService<Brand> repository, IMapper mapper, OnlineShopDbContext dbContext)
        {
            _generic = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<bool> IsUnique(BrandViewModel brand)
           => !await _dbContext.Brands.AsNoTracking().AnyAsync(b => b.Id != brand.Id && b.Title.Equals(brand.Title));

        public async Task<bool> CreateValidationAsync(BrandViewModel brand) =>
            await IsUnique(brand);

        public async Task<bool> UpdateValidationAsync(BrandViewModel brand)
        => await IsUnique(brand);

        public async Task<TransactionResult> CreateAsync(BrandViewModel model)
        {
            try
            {
                var validationResult = await CreateValidationAsync(model);
                var brand = _mapper.Map<Brand>(model);
                if (!validationResult)
                    return new TransactionResult
                    {
                        Type = ResultType.Error.ToString(),
                        Message = Messages.ItemExistsErrorMessage
                    };

                await _generic.UpdateAsync(brand);
                return new TransactionResult
                {
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

        public async Task<TransactionResult> DeleteAsync(int Id)
        {
            try
            {
                await _generic.DeleteAsync(Id);
                return new TransactionResult
                {
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

        public IQueryable<Brand> ReadAll() =>
            _generic.ReadAll();

        public async Task<BrandViewModel> ReadAsync(int Id)
        {
            var brand = await _generic.ReadAsync(Id);
            return _mapper.Map<BrandViewModel>(brand);
        }

        public async Task<TransactionResult> UpdateAsync(BrandViewModel model)
        {
            try
            {
                var validationResult = await UpdateValidationAsync(model);
                var brand = _mapper.Map<Brand>(model);
                if (!validationResult)
                    return new TransactionResult
                    {
                        Type = ResultType.Error.ToString(),
                        Message = Messages.ErrorTransactionMessage
                    };

                await _generic.UpdateAsync(brand);
                return new TransactionResult
                {
                    Type = ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch
            {
                return new TransactionResult
                {
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }
    }
}