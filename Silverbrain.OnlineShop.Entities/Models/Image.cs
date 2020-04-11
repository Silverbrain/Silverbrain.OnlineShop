using Silverbrain.OnlineShop.Entities.AuditableEntity;
using System;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class Image : IAuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
    }
}