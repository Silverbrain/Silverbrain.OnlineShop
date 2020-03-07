using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Repositories;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
using System;
using System.Linq;
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

        public async Task<TransactionResult> CreateAsync(BrandViewModel model, ModelStateDictionary modelState)
        {
            try
            {
                if (modelState.IsValid)
                {
                    var brand = _mapper.Map<Brand>(model);
                    await _repository.CreatAsync(brand);
                    return new TransactionResult
                    {
                        Type = TransactionResult.ResultType.Success.ToString(),
                        Message = Messages.SuccessfulTransactionMessage
                    };
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                return new TransactionResult
                {
                    Type = TransactionResult.ResultType.Error.ToString(),
                    Message = Messages.ErrorTransactionMessage,
                    Exception = e
                };
            }
        }

        public async Task<TransactionResult> DeleteAsync(int Id)
        {
            try
            {
                await _repository.DeleteAsync(Id);
                return new TransactionResult
                {
                    Type = TransactionResult.ResultType.Success.ToString(),
                    Message = Messages.SuccessfulTransactionMessage
                };
            }
            catch (Exception e)
            {
                return new TransactionResult
                {
                    Type = TransactionResult.ResultType.Error.ToString(),
                    Message = Messages.ErrorTransactionMessage,
                    Exception = e
                };
            }
        }

        public IQueryable<Brand> ReadAll() =>
            _repository.ReadAll();

        public async Task<BrandViewModel> ReadAsync(int Id)
        {
            var brand = await _repository.ReadAsync(Id);
            return _mapper.Map<BrandViewModel>(brand);
        }

        public async Task<TransactionResult> UpdateAsync(BrandViewModel model, ModelStateDictionary modelState)
        {
            try
            {
                if (modelState.IsValid)
                {
                    var brand = _mapper.Map<Brand>(model);
                    await _repository.UpdateAsync(brand);
                    return new TransactionResult
                    {
                        Type = TransactionResult.ResultType.Success.ToString(),
                        Message = Messages.SuccessfulTransactionMessage
                    };
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                return new TransactionResult
                {
                    Type = TransactionResult.ResultType.Error.ToString(),
                    Message = Messages.ErrorTransactionMessage,
                    Exception = e
                };
            }
        }
    }
}