using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silverbrain.OnlineShop.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManagementDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}