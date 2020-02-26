using Microsoft.AspNetCore.Identity;
using System;

namespace Silverbrain.OnlineShop.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
