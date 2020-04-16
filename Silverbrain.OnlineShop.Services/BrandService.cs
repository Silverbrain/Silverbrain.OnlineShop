using AutoMapper;
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
    public class BrandService : GenericService<Brand, int>, IBrandService
    {
        private readonly IMapper _mapper;

        public BrandService(OnlineShopDbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _mapper = mapper;
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
                if (!await CreateValidationAsync(model))
                    return new TransactionResult
                    {
                        IsSuccess = false,
                        Type = ResultType.Error.ToString(),
                        Message = Messages.ItemExistsErrorMessage
                    };
                //////////////////////////////////////////////////////image//////////////////////////////////////
                #region image_process

                #endregion
                ///////////////////////////////////////////////////eof image/////////////////////////////////////

                Brand brand = _mapper.Map<Brand>(model);
                TransactionResult transactionResult = await AddAsync(brand);
                if (transactionResult.IsSuccess)
                    transactionResult = await SaveChangesAsync();
                return transactionResult;
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess = false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }

        public async Task<BrandViewModel> GetByIdAsync(int Id)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var brand = await FindAsync(Id);
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            return _mapper.Map<BrandViewModel>(brand);
        }
        public async Task<TransactionResult> DeleteAsync(int id)
        {
            try
            { 
                TransactionResult transactionResult = Remove(id);
                if (transactionResult.IsSuccess)
                    transactionResult = await SaveChangesAsync();
                return transactionResult;
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess = false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }
        public async Task<TransactionResult> UpdateAsync(BrandViewModel model)
        {
            try
            {
                var validationResult = await UpdateValidationAsync(model);
                if (!validationResult)
                    return new TransactionResult
                    {
                        IsSuccess = false,
                        Type = ResultType.Error.ToString(),
                        Message = Messages.ErrorTransactionMessage
                    };
                var brand = _mapper.Map<Brand>(model);
                TransactionResult transactionResult = Update(brand);
                if (transactionResult.IsSuccess)
                    transactionResult = await SaveChangesAsync();
                return transactionResult;
            }
            catch
            {
                return new TransactionResult
                {
                    IsSuccess = false,
                    Type = ResultType.Error.ToString(),
                    Message = Messages.ServerErrorMessage
                };
            }
        }
    }
}