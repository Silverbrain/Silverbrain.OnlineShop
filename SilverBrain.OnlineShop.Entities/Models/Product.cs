using System;
using System.Collections.Generic;
using System.Text;

namespace SilverBrain.OnlineShop.Entities.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public ICollection<ProductImage> Images { get; set; }
    }
}
