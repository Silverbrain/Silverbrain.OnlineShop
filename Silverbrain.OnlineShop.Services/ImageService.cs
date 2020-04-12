using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;

namespace Silverbrain.OnlineShop.Services
{
    public class ImageService : GenericService<Image, string>, IImageService
    {
        public ImageService(OnlineShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}