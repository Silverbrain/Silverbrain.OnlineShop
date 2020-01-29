using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class ProductImage : Image
    {
        public Uri ThumbnailUrl { get; set; }

        public string Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}
