using Market.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Market.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly SignInManager<AspNetUsers> _signInManager;

        public LoginViewComponent(SignInManager<AspNetUsers> signInManager)
        {
            _signInManager = signInManager;
        }

        public IViewComponentResult Invoke()
        {
            if (_signInManager.IsSignedIn(User as ClaimsPrincipal))
            {
                return View("SignedIn");
            }
            return View("SignedOut");
        }
    }
}
