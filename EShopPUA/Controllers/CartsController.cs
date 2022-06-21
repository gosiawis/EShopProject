using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShopPUA.Models;
using System.Data;
using EShopPUA.Helpers;

namespace EShopPUA.Controllers
{
    public class CartsController : Controller
    {
        private readonly DatabaseEShopContext _context;

        public CartsController(DatabaseEShopContext context)
        {
            _context = context;
        }

        // GET: Carts
        //public async Task<IActionResult> Index()
        //{
        //    var databaseEShopContext = _context.Carts.Include(c => c.Product);
        //    return View(await databaseEShopContext.ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            return View(
                new CartViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    CartContentModels = cart,
                    PaymentMethods = await _context.PaymentMethods.ToListAsync(),
                    CartTotal = (int)cart.Sum(item => item.Product.Price * item.ProductQuantity)
                }
            );
        }

        public async Task<IActionResult> Checkout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            return View(
                new CartViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    CartContentModels = cart,
                    PaymentMethods = await _context.PaymentMethods.ToListAsync(),
                    CartTotal = (int)cart.Sum(item => item.Product.Price * item.ProductQuantity)
                }
            );
        }

        public class CartViewModel
        {
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<CartContentModel> CartContentModels { get; set; }

            public IEnumerable<PaymentMethod> PaymentMethods { get; set; }

            public int CartTotal { get; set; }
            //public IEnumerable<Product> Products { get; set; }
            //public IEnumerable<Brand> Brands { get; set; }
        }

        public class CartContentModel
        {
            public Product Product { get; set; }
            public int ProductQuantity { get; set; }
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            CartContentModel cartContentModel = new CartContentModel();
            if (SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart") == null)
            {
                List<CartContentModel> cart = new List<CartContentModel>();
                cart.Add(new CartContentModel { Product = await _context.Products.SingleAsync(p => p.Id == productId), ProductQuantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
                int index = isExist(productId);
                if (index != -1)
                {
                    cart[index].ProductQuantity++;
                }
                else
                {
                    cart.Add(new CartContentModel { Product = await _context.Products.SingleAsync(p => p.Id == productId), ProductQuantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DecreaseQuantity(int productId)
        {
            List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            int index = isExist(productId);
            if (cart[index].ProductQuantity == 1)
            {
                cart.RemoveAt(index);
            }
            else
            {
                cart[index].ProductQuantity--;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromCart(int productId)
        {
            List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            int index = isExist(productId);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowCart()
        {
            CartContentModel cartContentModel = new CartContentModel();
            if (SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart") == null)
            {
                List<CartContentModel> cart = new List<CartContentModel>();
                cart.Add(new CartContentModel { Product = await _context.Products.SingleAsync(p => p.Id == 1), ProductQuantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                int index = isExist(1);
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> ShowCheckout()
        {
            CartContentModel cartContentModel = new CartContentModel();
            if (SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart") == null)
            {
                List<CartContentModel> cart = new List<CartContentModel>();
                cart.Add(new CartContentModel { Product = await _context.Products.SingleAsync(p => p.Id == 1), ProductQuantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                int index = isExist(1);
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Checkout");
            }
            else
            {
                return RedirectToAction("Checkout");
            }
        }

        private int isExist(int productId)
        {
            List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(productId))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
