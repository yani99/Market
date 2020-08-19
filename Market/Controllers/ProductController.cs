using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Market.DAL.Models;
using Market.Services.Implementation;
using Market.Services;
using System.Collections.Generic;

namespace Market.Controllers
{
    public class ProductController : Controller
    {
        private readonly MarketDBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IProductService _productService;

        public ProductController(MarketDBContext context, IMapper mapper, UserManager<AspNetUsers> userManager, IProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _productService = productService;
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            var model = _mapper.Map<EditProductViewModel>(product);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateProductViewModel() { QualityList = _productService.QualitySelectList()};
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = _userManager.GetUserId(User);
                model.UserId = userid;
                var product = _mapper.Map<Product>(model);
                _productService.Create(product);
                return RedirectToAction("Index", "Home");
            }
            model.QualityList = _productService.QualitySelectList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var product = _productService.GetById(id);
            if (_userManager.GetUserId(User) == product.UserId)
            {
                _productService.Update(product);
            }
            var model = _mapper.Map<EditProductViewModel>(product);
            model.QualityList = _productService.QualitySelectList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = _userManager.GetUserId(User);
                var product = _productService.GetById(model.Id);
                _mapper.Map(model, product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            model.QualityList = _productService.QualitySelectList();
            return View(model);
        }
    }
}