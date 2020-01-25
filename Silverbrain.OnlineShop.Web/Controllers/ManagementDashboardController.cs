﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Web.Models.ViewModels;

namespace Silverbrain.OnlineShop.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagementDashboardController : Controller
    {
        public IActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>
            {
                new UserViewModel{FirstName = "sina", LastName = "ataei", Username = "silverbrain" },
                new UserViewModel{FirstName = "ali", LastName = "emami", Username = "alikhan" },
                new UserViewModel{FirstName = "hassan", LastName = "hassani", Username = "hassani" },
                new UserViewModel{FirstName = "amin", LastName = "farahmand", Username = "aminfar" },
                new UserViewModel{FirstName = "mohammad", LastName = "rahimi", Username = "more13" },
                new UserViewModel{FirstName = "reza", LastName = "mohammadpour", Username = "rezmo" },
                new UserViewModel{FirstName = "mina", LastName = "esmaeili", Username = "minesmal" },
                new UserViewModel{FirstName = "elnaz", LastName = "mahzoon", Username = "eli" },
                new UserViewModel{FirstName = "asal", LastName = "ataei", Username = "asat" },
                new UserViewModel{FirstName = "neda", LastName = "shariari", Username = "nedsss" },
                new UserViewModel{FirstName = "soorena", LastName = "ataei", Username = "soorenaAt" },
            };

            return View(users);
        }
    }
}