namespace Silverbrain.OnlineShop.Entities.Models
{
    public class BrandImage : Image
    {
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}