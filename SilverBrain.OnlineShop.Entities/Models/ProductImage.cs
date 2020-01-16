using System;

namespace SilverBrain.OnlineShop.Entities.Models
{
    public class ProductImage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Uri ImageUrl { get; set; }
        public Uri ImageThumbnail { get; set; }

        public string Product_Id { get; set; }
        //[ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}