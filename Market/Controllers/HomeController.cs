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
using Microsoft.AspNetCore.Identity;
using Market.ViewModels;
using Market.Services;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        private readonly IMapper _mapper;

        private readonly UserManager<AspNetUsers> userManager;

        private readonly ICreatePostService createPostService;

        public HomeController(ILogger<HomeController> logger,IMapper mapper,UserManager<AspNetUsers> userManager,ICreatePostService createPostService)
        {
            _logger = logger;
            _mapper = mapper;
            this.userManager = userManager;
            this.createPostService = createPostService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePostViewModel input)
        {
            var user = userManager.GetUserId(this.User);
            createPostService.CreatePost(input.Title, input.Description, input.Price, input.Quantity, user);
            return this.View();
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
