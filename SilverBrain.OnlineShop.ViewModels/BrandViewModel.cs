using Microsoft.AspNetCore.Http;
using Silverbrain.OnlineShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BrandImage Image { get; set; }
        public IFormFile ImageFormFile { get; set; }
    }
}
