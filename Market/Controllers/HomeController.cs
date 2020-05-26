using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Market.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Market.ViewModels;
using AutoMapper.Configuration.Conventions;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MarketDBContext _context;

        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IMapper mapper, MarketDBContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
           var product =   PaginatedListViewModel<Product>.CreateAsync(_context.Product , page , 5);
            return View(product);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Edit(int Id)
        {
            var _product = new Product
            {
                Id = 6,
                Description = "Porcelanova chasha",
                Title = "Chasha",
                Price = 14
            };
            var ViewModel = _mapper.Map<EditProductViewModel>(_product);
            return View(ViewModel);
        }
    }
}