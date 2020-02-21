using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.ViewModels;

namespace Silverbrain.OnlineShop.Web.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Dashboard")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }

        // GET: Brand/Details/5
        public async Task<ActionResult> Read(int id) =>
            Ok(await _brandService.ReadAsync(id));

        public async Task<ActionResult> ReadAll([DataSourceRequest] DataSourceRequest request)
        {
            var result = await _brandService.ReadAllAsync();
            return Json(result.ToDataSourceResult(request));
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BrandViewModel model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {

                    if (model.ImageFormFile.Length > 0)
                    {

                    }

                    var brand = _mapper.Map<Brand>(model);
                    await _brandService.CreateAsync(brand);
                    return Json(true);
                }

                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Update()
        {
            return View();
        }

        // POST: Brand/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            BrandViewModel model)
        {
            try
            {
                var brand = _mapper.Map<Brand>(model);
                _brandService.UpdateAsync(brand);
                return Json(new[] { brand }.ToDataSourceResult(request, ModelState));
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request,
            BrandViewModel model)
        {
            try
            {
                if(model != null)
                {
                    _brandService.DeleteAsync(model.Id);
                }

                return Json(new[] { model }.ToDataSourceResult(request,ModelState));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}