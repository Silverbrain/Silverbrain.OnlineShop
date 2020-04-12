using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Web.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Dashboard")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _webHost;

        public BrandController(IBrandService brandService, IWebHostEnvironment webHost)
        {
            _brandService = brandService;
            _webHost = webHost;
        }

        [HttpGet]
        public ActionResult Index() => View();

        [HttpPost]
        public IActionResult ReadAll([DataSourceRequest] DataSourceRequest request) =>
            Json(_brandService.ReadAll().ToDataSourceResult(request));

        [HttpGet]
        public ActionResult Create() => PartialView();

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(BrandViewModel model)
        {
            TransactionResult transactionResult = new TransactionResult();
            if (ModelState.IsValid)
            {
                var imageFile = Request.Form.Files[0];

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                fileName = fileName.Trim('-');
                var filepath = _webHost.WebRootPath + Constants.PathBrandImage;

                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);

                var imagePath = Path.Combine(filepath, fileName);

                if (imageFile.Length > 0)
                {
                    using var stream = new FileStream(imagePath, FileMode.Create);
                    await imageFile.CopyToAsync(stream);
                    await stream.DisposeAsync();
                }

                model.Image = new BrandImage { Title = fileName };

                transactionResult = await _brandService.CreateAsync(model);
            }
            else
            {
                transactionResult.IsSuccess = false;
                transactionResult.Type = ResultType.Error.ToString();
                transactionResult.Message = Messages.ErrorTransactionMessage;
            };
            return Json(transactionResult);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id) => PartialView(await _brandService.GetByIdAsync(Id));

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
                return (Json(await _brandService.UpdateAsync(model)));

            var result = new TransactionResult
            {
                Type = ResultType.Error.ToString(),
                Message = Messages.ErrorTransactionMessage
            };
            return Json(result);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int Id) => Json(await _brandService.DeleteAsync(Id));
    }
}