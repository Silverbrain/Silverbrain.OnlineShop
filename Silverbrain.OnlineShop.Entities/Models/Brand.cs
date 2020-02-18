﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BrandImage Image { get; set; }
    }
}