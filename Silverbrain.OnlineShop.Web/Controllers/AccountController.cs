﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Services;
using Silverbrain.OnlineShop.Web.Models.ViewModels;

namespace Silverbrain.OnlineShop.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountManagementService _accountService;

        public AccountController(IAccountManagementService accountService)
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
            var result = await _accountService.LoginAsync("Admin", "Admin", true);

            if (result.Succeeded)
                return RedirectToAction("Index", "ManagementDashboard");
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}