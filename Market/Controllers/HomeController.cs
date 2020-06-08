using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Market.ViewModels;
using Market.Services;
using Market.DAL.Models;
using Market.Services.Implementation;

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
        public IActionResult Index(int currentPage = 1)
        {
            var model = new PaginatedListViewModel();
            var productService = new ProductService(_context);
            model.Data = productService.GetPaginatedResult(currentPage);
            model.Count = productService.GetCount();
            model.CurrentPage = currentPage;
            return View(model);
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
    }
}