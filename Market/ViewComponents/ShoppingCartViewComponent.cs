using Market.DAL.Models;
using Market.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Market.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IUserService _userService;

        public ShoppingCartViewComponent(UserManager<AspNetUsers> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _userService.GetCurrentOrdersCount(_userManager.GetUserId(User as ClaimsPrincipal)));
        }
    }
}
