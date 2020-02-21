using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.WebAPI
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    class AccountAPIController : Controller
    {
        private readonly IAccountManagementService _accountManagement;

        public AccountAPIController(IAccountManagementService accountManagement)
        {
            _accountManagement = accountManagement;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAccountByIdAsync([FromRoute] string Id) =>
            Ok(await _accountManagement.GetAsync(Id));

        [HttpGet]
        public async Task<IActionResult> GetAccountAsync() =>
            new ObjectResult(await _accountManagement.GetAllAsync());
    }
}
