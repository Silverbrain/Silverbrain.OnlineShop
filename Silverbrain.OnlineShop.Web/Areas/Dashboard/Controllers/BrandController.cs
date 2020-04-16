using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Common;
using Silverbrain.OnlineShop.Entities.Enums;
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

                var fileName = model.Title + Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
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

                model.ImageName = fileName;

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
        public async Task<ActionResult> Edit(BrandViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var filePath = _webHost.WebRootPath + Constants.PathBrandImage;
                var brand = await _brandService.GetByIdAsync((int)model.Id);

                if (model.ImageName != null)
                {
                    var imageFile = Request.Form.Files[0];
                    if (brand.ImageName != imageFile.FileName)
                    {
                        await DeleteImageAsync(filePath, brand.ImageName);
                    }

                    model.ImageName = await SaveImageAsync(Request.Form.Files[0], filePath, model.Title);
                }
                else
                {
                    if (!string.IsNullOrEmpty(brand.ImageName))
                    {
                        await DeleteImageAsync(filePath, brand.ImageName);
                    }
                }

                return (Json(await _brandService.UpdateAsync(model)));
            }

            var result = new TransactionResult
            {
                Type = ResultType.Error.ToString(),
                Message = Messages.ErrorTransactionMessage
            };
            return Json(result);
        }

        public async Task DeleteImageAsync(string filePath, string imageName)
        {
            await Task.Run(() =>
            {
                if (Directory.Exists(filePath))
                {
                    var imagePath = Path.Combine(filePath, imageName);

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            });
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string filePath, string modelTitle)
        {
            var fileName = modelTitle + Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            fileName = fileName.Trim('-');

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            var imagePath = Path.Combine(filePath, fileName);

            if (imageFile.Length > 0)
            {
                using var stream = new FileStream(imagePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                await stream.DisposeAsync();
            }

            return fileName;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var filePath = _webHost.WebRootPath + Constants.PathBrandImage;
            var brand = await _brandService.FindAsync(Id);
            if (!string.IsNullOrEmpty(brand.ImageName))
                await DeleteImageAsync(filePath, brand.ImageName);

            return Json(await _brandService.DeleteAsync(Id));
        }
    }
}