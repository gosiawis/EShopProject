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
            if (filters.SelectedBrands is null || filters.SelectedCategories is null)
            {
                products = await _context.Products.ToListAsync();
            }
            else
            {
                products = await _context.Products
                    .Where(p => filters.SelectedBrands.Contains(p.BrandId) && filters.SelectedCategories.Contains(p.CategoryId))
                    .ToListAsync();
            }
            return View(
                new ShopViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    Products = products,
                    Brands = await _context.Brands.ToListAsync(),
                    CountProducts = new CountProducts { Products = await _context.Products.ToListAsync()}
                }
            );
        }

        public class ShopFilters
        {
            public IEnumerable<int>? SelectedBrands { get; set; }
            public IEnumerable<int>? SelectedCategories { get; set; }
            public IEnumerable<int>? SelectedPrices { get; set; }

        }

        public class BrandViewModel
        {
            
            public IEnumerable<Brand>? Brands { get; set; }

        }

        public class ShopViewModel
        {
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<Product> Products { get; set; }
            public IEnumerable<Brand> Brands { get; set; }

            public CountProducts? CountProducts { get; set; }
        }

        public class CountProducts
        {
            public IEnumerable<Product>? Products { get; set; }
            public int TotalProducts
            {
                get
                {
                    return Products.Count();
                }
            }
            public int BrandProducts(int? id)
            {
                return Products.Count(p => p.BrandId == id);
            }

            public int CategoryProducts(int? id)
            {
                return Products.Count(p => p.CategoryId == id);
            }

            public int PriceProducts(int? lowerBound, int? upperBound)
            {
                return Products.Count(p => p.Price >= lowerBound && p.Price <= upperBound);
            }

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


}