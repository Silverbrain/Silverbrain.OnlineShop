using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Repositories;
using Silverbrain.OnlineShop.Repositories.Brand;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _genericRepo;
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> repository, IMapper mapper, IBrandRepository brandRepo)
        {
            _genericRepo = repository;
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public async Task<TransactionResult> CreateAsync(BrandViewModel model)
        {
            try
            {
                var brand = _mapper.Map<Brand>(model);
                var validationResult = await _brandRepo.CreateValidationAsync(brand);
                if (validationResult.Type == ResultType.Error.ToString())
                    return validationResult;

                await _genericRepo.CreatAsync(brand);
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
                await _genericRepo.DeleteAsync(Id);
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
            _genericRepo.ReadAll();

        public async Task<BrandViewModel> ReadAsync(int Id)
        {
            var brand = await _genericRepo.ReadAsync(Id);
            return _mapper.Map<BrandViewModel>(brand);
        }

        public async Task<TransactionResult> UpdateAsync(BrandViewModel model)
        {
            try
            {
                var brand = _mapper.Map<Brand>(model);
                var validationResult = await _brandRepo.UpdateValidationAsync(brand);
                if (validationResult.Type == ResultType.Error.ToString())
                    return validationResult;

                await _genericRepo.UpdateAsync(brand);
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