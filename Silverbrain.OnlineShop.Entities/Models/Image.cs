using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Uri URL { get; set; }
    }
}
