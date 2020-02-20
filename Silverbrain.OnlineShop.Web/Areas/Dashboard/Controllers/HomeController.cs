using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.ViewModels;

namespace Silverbrain.OnlineShop.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            List<UserViewModel> aa = new List<UserViewModel>()
            {
                new UserViewModel{Id=1,FirstName = "sina", LastName = "ataei", UserName = "silverbrain" },
                new UserViewModel{Id=2,FirstName = "ali", LastName = "emami", UserName = "alikhan" },
                new UserViewModel{Id=3,FirstName = "hassan", LastName = "hassani", UserName = "hassani" },
                new UserViewModel{Id=4,FirstName = "amin", LastName = "farahmand", UserName = "aminfar" },
                new UserViewModel{Id=5,FirstName = "mohammad", LastName = "rahimi", UserName = "more13" },
                new UserViewModel{Id=6,FirstName = "reza", LastName = "mohammadpour", UserName = "rezmo" },
                new UserViewModel{Id=7,FirstName = "mina", LastName = "esmaeili", UserName = "minesmal" },
                new UserViewModel{Id=8,FirstName = "elnaz", LastName = "mahzoon", UserName = "eli" },
                new UserViewModel{Id=9,FirstName = "asal", LastName = "ataei", UserName = "asat" },
                new UserViewModel{Id=10,FirstName = "neda", LastName = "shariari", UserName = "nedsss" },
                new UserViewModel{Id=11,FirstName = "soorena", LastName = "ataei", UserName = "soorenaAt" }
            };
            return Json(aa.ToList().ToDataSourceResult(request));
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}