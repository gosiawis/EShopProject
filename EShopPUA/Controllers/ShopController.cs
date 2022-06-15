using EShopPUA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EShopPUA.Controllers
{
    //[Authorize]
    public class ShopController : Controller
    {
        private readonly DatabaseEShopContext _context;
        private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger, DatabaseEShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(ShopFilters filters)
        {
            IEnumerable<Product> products;
            if (filters.IsAllSelected || filters.SelectedBrands is null)
            {
                products = await _context.Products.ToListAsync();
            }
            else
            {
                products = await _context.Products
                    .Where(p => filters.SelectedBrands.Contains(p.BrandId))
                    .ToListAsync();
            }
            return View(
                new ShopViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    Products = products,
                    Brands = await _context.Brands.ToListAsync()
                }
            );
        }

        public class ShopFilters
        {
            public string? IsAllSelectedString { get; set; }
            public bool IsAllSelected => IsAllSelectedString == "on" ? true : false;
            public IEnumerable<int>? SelectedBrands { get; set; }
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

    public class ShopViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

    }
}