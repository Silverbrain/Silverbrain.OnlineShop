﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class ProductImage : Image
    {
        public Uri ThumbnailUrl { get; set; }

        public string Product_Id { get; set; }
        public Product Product { get; set; }
    }
}
