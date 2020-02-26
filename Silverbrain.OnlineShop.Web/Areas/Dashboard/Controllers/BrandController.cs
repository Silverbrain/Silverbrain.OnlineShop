﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Brand/Details/5
        public async Task<ActionResult> Read(int id) =>
            Ok(await _brandService.ReadAsync(id));

        [HttpPost]
        public async Task<ActionResult> ReadAll([DataSourceRequest] DataSourceRequest request)
        {
            var brands = await _brandService.ReadAllAsync();
            var result = brands.Select(b => new BrandViewModel { Id = b.Id, Title = b.Title, Image = b.Image.Title }).ToList();

            return Json(result.ToDataSourceResult(request));
        }

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
                var ms = ModelState;
                if (model != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFormFile.FileName);
                    fileName = fileName.Trim('-');
                    //var filepath = Path.Combine(_webHost.WebRootPath , "\\assets\\images\\brands");
                    var filepath = _webHost.WebRootPath + Constants.PathBrandImage;
                    var imagePath = Path.Combine(filepath, fileName);

                    if (model.ImageFormFile.Length > 0)
                    {
                        using var stream = new FileStream(imagePath, FileMode.Create);
                        await model.ImageFormFile.CopyToAsync(stream);
                        await stream.DisposeAsync();
                    }

                    var brand = new Brand
                    {
                        Image = new BrandImage { Title = fileName },
                        Title = model.Title
                    };

                    await _brandService.CreateAsync(brand);
                    return Json(true);
                }

                HttpContext.Response.Headers.Append("error-message", ModelState.Values.ToString());
                return BadRequest();
            }
            catch (Exception e)
            {
                HttpContext.Response.Headers.Append("error-message", e.Message.ToString());
                return BadRequest();
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Brand/Edit/5
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request,
            BrandViewModel model)
        {
            try
            {
                if (model.ImageFormFile == null)
                {
                    var brand = new Brand { Id = model.Id, Image = new BrandImage { Title = model.Image }, Title = model.Title };
                    await _brandService.UpdateAsync(brand);
                    return Json(true);
                }
                else
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFormFile.FileName);
                    fileName = fileName.Trim('-');
                    //var filepath = Path.Combine(_webHost.WebRootPath , "\\assets\\images\\brands");
                    var filepath = _webHost.WebRootPath + Constants.PathBrandImage;
                    var imagePath = Path.Combine(filepath, fileName);

                    if (model.ImageFormFile.Length > 0)
                    {
                        ///<summary>
                        ///save new image into hard drive
                        ///</summary>
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await model.ImageFormFile.CopyToAsync(stream);
                            await stream.DisposeAsync();
                        }

                        ///<summary>
                        ///delete the old image from the hard drive
                        ///</summary>
                        imagePath = Path.Combine(filepath, model.Image);
                        if (System.IO.File.Exists(filepath))
                            System.IO.File.Delete(imagePath);
                    }

                    var brand = new Brand { Id = model.Id, Image = new BrandImage { Title = fileName }, Title = model.Title };
                    await _brandService.UpdateAsync(brand);

                    return Json(true);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Brand/Delete/5
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, int Id)
        {
            try
            {
                _brandService.DeleteAsync(Id);
                return Json(true);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}