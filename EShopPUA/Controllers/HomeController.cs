﻿using EShopPUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EShopPUA.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly DatabaseEShopContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DatabaseEShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel { Categories = await _context.Categories.ToListAsync() });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

    }
}