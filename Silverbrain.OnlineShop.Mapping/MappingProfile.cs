using AutoMapper;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandViewModel, Brand>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}
