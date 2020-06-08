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
    public class OrderController : Controller
    {

        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(UserManager<AspNetUsers> userManager,
            IMapper mapper, IOrderService orderService,IProductService productService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Order(int id)
        {
            var product = _productService.GetById(id);
            var order = _mapper.Map<Order>(product);
            order.UserId = _userManager.GetUserId(User);         
            var entity =  _orderService.Add(order);
            product.OrderId = entity.Entity.Id;
            _productService.Update(product);
            return RedirectToAction("Index", "ShoppingCart");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            if (_orderService.Remove(id))
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}