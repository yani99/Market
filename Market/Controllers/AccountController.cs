using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Models;
using Market.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;

        public AccountController(UserManager<AspNetUsers> userManager,
           SignInManager<AspNetUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #region login
        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("MyAccount");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid attempt");
            }
            return View(model);
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("MyAccount");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AspNetUsers()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return View("SuccessRegistration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        #endregion

        [HttpGet]
        public IActionResult MyAccount()
        {
            return View();
        }
    }
}