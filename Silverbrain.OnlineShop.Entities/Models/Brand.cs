using Silverbrain.OnlineShop.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class Brand: IAuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
