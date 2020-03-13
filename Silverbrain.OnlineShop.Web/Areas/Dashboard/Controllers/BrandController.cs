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

        // GET: Brand
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReadAll([DataSourceRequest] DataSourceRequest request) =>
            Json(_brandService.ReadAll().ToDataSourceResult(request));

        // GET: Brand/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
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
            if (ModelState.IsValid)
                return Json(await _brandService.CreateAsync(model));

            var result = new TransactionResult
            {
                Type = ResultType.Error.ToString(),
                Message = Messages.ErrorTransactionMessage
            };
            return Json(result);
        }

        // GET: Brand/Edit/5
        [HttpGet]
        public async Task<ActionResult> Update(int Id)
        {
            var brand = await _brandService.ReadAsync(Id);
            return View(brand);
        }

        // POST: Brand/Edit/5
       [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Update(BrandViewModel model)
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

        // POST: Brand/Delete/5
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _brandService.DeleteAsync(Id);
            return Json(result);
        }
    }
}