using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Services;
using Silverbrain.OnlineShop.Web.Models.ViewModels;

namespace Silverbrain.OnlineShop.Web.Controllers
{
    public class AccountController : Controller
    {
        IAcountManagementService _accountService;

        public AccountController(IAcountManagementService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            _accountService.LoginAsync(userName: model.Username, password: model.Password).Wait();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogOutAsync();
            return View();
        }
    }
}