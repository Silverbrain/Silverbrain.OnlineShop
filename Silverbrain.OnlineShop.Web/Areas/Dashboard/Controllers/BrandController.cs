using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Resources;
using Silverbrain.OnlineShop.ViewModels;

namespace Silverbrain.OnlineShop.Web.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Dashboard")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;

        public BrandController(IBrandService brandService, IMapper mapper, IWebHostEnvironment webHost)
        {
            _brandService = brandService;
            _mapper = mapper;
            _webHost = webHost;
        }

        // GET: Brand
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Brand/Details/5
        public async Task<ActionResult> Read(int id) =>
            Ok(await _brandService.ReadAsync(id));

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
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(BrandViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
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
                    await _brandService.CreateAsync(model);
                    return Json(true);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Brand/Edit/5
        [HttpGet]
        public async Task<ActionResult> Update(int Id)
        {
            var brand = await _brandService.ReadAsync(Id);
            return View(brand);
        }

        // POST: Brand/Edit/5
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Update(BrandViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _brandService.UpdateAsync(model);
                    return Json(true);
                }
                return BadRequest(ModelState);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: Brand/Delete/5
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                _brandService.DeleteAsync(Id);
                return Json(true);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}