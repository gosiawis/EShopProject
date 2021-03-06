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

        //MODELS DEFINITIONS

        public class ClientDataModel
        {
            public string? ClientName { get; set; }
            public string? ClientSurname { get; set; }
            public string? ClientEmail { get; set; }
            public string? ClientPhone { get; set; }
            public string? ClientStreet { get; set; }
            public int? ClientHouseNumber { get; set; }
            public int? ClientApartmentNumber { get; set; } = null;

            public string? ClientCity { get; set; }
            public string? ClientZipCode { get; set; }
            public string? ClientVoivodeship { get; set; }
            public int? PaymentId { get; set; }
        }

        public class OrderViewModel
        {
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<CartContentModel> CartContentModels { get; set; }

            public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
            public IEnumerable<Voivodeship> Voivodeships { get; set; }

            public int CartTotal { get; set; }

            public ClientDataModel ClientDataModel { get; set; }

            public string PaymentMethodName { get; set; }
        }

        public class CartViewModel
        {
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<CartContentModel> CartContentModels { get; set; }

            public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
            public IEnumerable<Voivodeship> Voivodeships { get; set; }

            public int CartTotal { get; set; }
            //public IEnumerable<Product> Products { get; set; }
            //public IEnumerable<Brand> Brands { get; set; }
        }

        public class CartContentModel
        {
            public Product Product { get; set; }
            public int ProductQuantity { get; set; }
        }

        //ACTIONS
        //Index + ShowVart = cart view
        public async Task<IActionResult> Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            return View(
                new CartViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    CartContentModels = cart,
                    PaymentMethods = await _context.PaymentMethods.ToListAsync(),
                    Voivodeships = await _context.Voivodeships.ToListAsync(),
                    CartTotal = (int)cart.Sum(item => item.Product.Price * item.ProductQuantity)
                }
            );
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

        //AddToCart - adds to cart or increases the quantity of products
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

        //DecreaseQuantity - removes from cart or decreases the quantity of products
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

        //RemoveFromCart - removes from cart
        public IActionResult RemoveFromCart(int productId)
        {
            List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            int index = isExist(productId);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


        //Checkout + ShowCheckout = checkout view
        public async Task<IActionResult> Checkout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            return View(
                new CartViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    CartContentModels = cart,
                    PaymentMethods = await _context.PaymentMethods.ToListAsync(),
                    Voivodeships = await _context.Voivodeships.ToListAsync(),
                    CartTotal = (int)cart.Sum(item => item.Product.Price * item.ProductQuantity)
                }
            );
        }

        public async Task<IActionResult> ShowCheckout()
        {
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

        //OrderPlaced = order summary view
        public async Task<IActionResult> OrderPlaced(ClientDataModel clientDataModel)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            var pm = await _context.PaymentMethods.ToListAsync();
            var pmn = pm.Single(p => p.Id == clientDataModel.PaymentId).Name;
            return View(
                new OrderViewModel
                {
                    Categories = await _context.Categories.ToListAsync(),
                    CartContentModels = cart,
                    PaymentMethods = pm,
                    Voivodeships = await _context.Voivodeships.ToListAsync(),
                    CartTotal = (int)cart.Sum(item => item.Product.Price * item.ProductQuantity),
                    ClientDataModel = clientDataModel,
                    PaymentMethodName = pmn
                }
            );
        }
        //CreateOrder = writes the order and client data to DB
        public async Task<IActionResult> CreateOrder(ClientDataModel clientDataModel)
        {
            IEnumerable<Voivodeship> voivodeships = await _context.Voivodeships.ToListAsync();
            List<Client> clients = await _context.Clients.ToListAsync();
            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            int clientId;
            //var clientId = clients.FirstOrDefault(c => c.Email == clientDataModel.ClientEmail).Id;
            if (clients.FirstOrDefault(c => c.Email == clientDataModel.ClientEmail) is null)
            {
                Client client = new Client
                {
                    Name = clientDataModel.ClientName,
                    Surname = clientDataModel.ClientSurname,
                    Email = clientDataModel.ClientEmail,
                    VoivodeshipId = voivodeships.Single(v => v.Name == clientDataModel.ClientVoivodeship).Id,
                    City = clientDataModel.ClientCity,
                    Street = clientDataModel.ClientStreet,
                    HouseNumber = (int)clientDataModel.ClientHouseNumber,
                    ApartmentNumber = clientDataModel.ClientApartmentNumber,
                    ZipCode = clientDataModel.ClientZipCode
                };

                _context.Add(client);
                await _context.SaveChangesAsync();
                clients = await _context.Clients.ToListAsync();
                clientId = client.Id;
            }
            else
            {
                clientId = clients.FirstOrDefault(c => c.Email == clientDataModel.ClientEmail).Id;
            }
            Order order = new Order
            {
                ClientId = clientId,
                OrderStatusId = 1,
                PaymentStatusId = 1,
                PaymentMethodId = (int)clientDataModel.PaymentId,
                Price = (int)cart.Sum(item => item.Product.Price * item.ProductQuantity)
            };
            _context.Add(order);
            await _context.SaveChangesAsync();
            IEnumerable<Order> orders = await _context.Orders.ToListAsync();
            int orderId = order.Id;
            foreach (var item in cart)
            {
                OrderItem orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ProductId = item.Product.Id,
                    ProductQuantity = item.ProductQuantity
                };
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("OrderPlaced", clientDataModel);
        }

        //isExist - gets the id of the product
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
