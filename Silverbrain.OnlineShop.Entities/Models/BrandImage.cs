using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class BrandImage : Image
    {
        public int Brand_Id { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
