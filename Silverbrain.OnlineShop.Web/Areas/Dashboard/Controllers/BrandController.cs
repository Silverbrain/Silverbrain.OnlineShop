﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Enums;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;
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
        public ActionResult Index()=> View();

        [HttpPost]
        public IActionResult ReadAll([DataSourceRequest] DataSourceRequest request) =>
            Json(_brandService.ReadAll().ToDataSourceResult(request));

        [HttpGet]
        public ActionResult Create() => PartialView();

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(BrandViewModel model)
        {
            //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFormFile.FileName);
            //fileName = fileName.Trim('-');
            ////var filepath = Path.Combine(_webHost.WebRootPath , "\\assets\\images\\brands");
            //var filepath = _webHost.WebRootPath + Constants.PathBrandImage;
            //var imagePath = Path.Combine(filepath, fileName);

            //if (model.ImageFormFile.Length > 0)
            //{
            //    using var stream = new FileStream(imagePath, FileMode.Create);
            //    await model.ImageFormFile.CopyToAsync(stream);
            //    await stream.DisposeAsync();
            //}

            //var brand = new Brand
            //{
            //    Image = new BrandImage { Title = fileName },
            //};
            TransactionResult transactionResult = new TransactionResult();
            if (ModelState.IsValid)
                transactionResult = await _brandService.CreateAsync(model);
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