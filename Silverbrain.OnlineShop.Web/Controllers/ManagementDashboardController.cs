using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.ViewModels;

namespace Silverbrain.OnlineShop.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ManagementDashboardController : Controller
    {
        public ActionResult Index() => View();
        public IActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            List<UserViewModel> aa = new List<UserViewModel>()
            {
                new UserViewModel{FirstName = "sina", LastName = "ataei", UserName = "silverbrain" },
                new UserViewModel{FirstName = "ali", LastName = "emami", UserName = "alikhan" },
                new UserViewModel{FirstName = "hassan", LastName = "hassani", UserName = "hassani" },
                new UserViewModel{FirstName = "amin", LastName = "farahmand", UserName = "aminfar" },
                new UserViewModel{FirstName = "mohammad", LastName = "rahimi", UserName = "more13" },
                new UserViewModel{FirstName = "reza", LastName = "mohammadpour", UserName = "rezmo" },
                new UserViewModel{FirstName = "mina", LastName = "esmaeili", UserName = "minesmal" },
                new UserViewModel{FirstName = "elnaz", LastName = "mahzoon", UserName = "eli" },
                new UserViewModel{FirstName = "asal", LastName = "ataei", UserName = "asat" },
                new UserViewModel{FirstName = "neda", LastName = "shariari", UserName = "nedsss" },
                new UserViewModel{FirstName = "soorena", LastName = "ataei", UserName = "soorenaAt" }
            };
            return Json(aa.ToList().ToDataSourceResult(request));
        }
    }
}