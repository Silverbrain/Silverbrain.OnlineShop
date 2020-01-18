using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Web.Models.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public bool isPersistence { get; set; }
    }
}
