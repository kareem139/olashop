using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using olashop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;

namespace olashop.Controllers
{
    public class ShoppingCart : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Cart _cart;
        public ShoppingCart(ApplicationDbContext dbContext,Cart cart)
        {
            _dbContext = dbContext;
            _cart = cart;
        }
        public IActionResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;

            var cartitemvm = new CartItemsVM
            {
                Cart = _cart,
                totalitemprice = _cart.GetCartTotalPrice()
            };
            return View(cartitemvm);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var res = _dbContext.Products.FirstOrDefault(r => r.Id == id);
            if (res != null)
            {
                _cart.AddToCart(res, 1);

            }


            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemovefromCart(int id)
        {
            var res = _dbContext.Products.FirstOrDefault(r => r.Id == id);
            if (res != null)
            {
                _cart.RemoveFromCart(res);

            }


            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart(int id)
        {
           
                _cart.ClearCart();

            


            return RedirectToAction("Index");
        }
    }
}
