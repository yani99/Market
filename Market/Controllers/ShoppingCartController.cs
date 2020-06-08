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
        private readonly IOrderService _orderService;

        public ShoppingCartController(UserManager<AspNetUsers> userManager,
            IMapper mapper, IUserService userService, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var count = await _userService.GetOrdersCountAsync(userId);
            if (count == 0) { return View("Empty"); }
            var list = _mapper.Map<List<OrderViewModel>>(_userService.GetAllOrders(userId));
            foreach (var item in list)
            {
                item.ShipperList = ShipperSelectList();
            };
            return View(list);
        }

        private List<SelectListItem> ShipperSelectList()
        {
            return _orderService.GetAllShippers()
                       .Select(a => new SelectListItem()
                       {
                           Value = a.Id.ToString(),
                           Text = a.CompanyName
                       })
                       .ToList();
        }
    }
}