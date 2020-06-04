using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market.Models;
using Market.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Market.Controllers
{
    public class ProductController : Controller
    {
        private readonly MarketDBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AspNetUsers> _userManager;

        public ProductController(MarketDBContext context, IMapper mapper, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<EditProductViewModel>(product);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var list = _context.Quality
                           .Select(a => new SelectListItem()
                           {
                               Value = a.Id.ToString(),
                               Text = a.Quality1
                           })
                           .ToList();
            var model = new CreateProductViewModel() { QualityList = list };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = _userManager.GetUserId(User);
                model.UserId = userid;
                var product = _mapper.Map<Product>(model);
                await _context.Product.AddAsync(product);
                 await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<EditProductViewModel>(product);
            var list = _context.Quality
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Quality1
                          })
                          .ToList();
            model.QualityList = list;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = _userManager.GetUserId(User);
                var product = _context.Product.FirstOrDefault(p => p.Id == model.Id);
                 _mapper.Map(model,product);
                await _context.SaveChangesAsync();
               return RedirectToAction("Index" , "Home" );
               
            }
            var list = _context.Quality
                         .Select(a => new SelectListItem()
                         {
                             Value = a.Id.ToString(),
                             Text = a.Quality1
                         })
                         .ToList();
            model.QualityList = list;
            return View(model);
        }
    }
}