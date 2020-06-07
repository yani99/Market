using AutoMapper;
using Market.DAL.Models;
using Market.Services;
using Market.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly MarketDBContext _context;

        public ShoppingCartController(UserManager<AspNetUsers> userManager,
            IMapper mapper, IUserService userService, MarketDBContext context)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var count = await _userService.GetOrdersCountAsync(userId);
            if (count == 0) { return View("Empty"); }

            return View();
        }
    }
}