﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string NameEnglish { get; set; }
        public string NamePersian { get; set; }

        public ICollection<ProductImage> Images { get; set; }
    }
}
