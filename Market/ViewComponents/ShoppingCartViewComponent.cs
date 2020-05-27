using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {

        public ShoppingCartViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            // TODO _context.Orders.count();
            var ordersCount = 0;
            return View(ordersCount);
        }
    }
}
