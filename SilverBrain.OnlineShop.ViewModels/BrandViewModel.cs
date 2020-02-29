using Microsoft.AspNetCore.Http;
using Silverbrain.OnlineShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Silverbrain.OnlineShop.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; } = 0;

        [MaxLength(50)]
        public string Title { get; set; }
    }
}
