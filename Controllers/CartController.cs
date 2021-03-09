using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using olashop.Helpers;
using olashop.Models;
using olashop.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                int final = 0;
                foreach (var item in cart)
                {
                    final = final + item.Quantity;
                };
                ViewBag.count = final;
            }
    
            return View();
        }

        
        public IActionResult Buy(int id)
        {
            
            if (SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart") == null)
            {
                List<RealCart> cart = new List<RealCart>();
                cart.Add(new RealCart { Product = _dbContext.Products.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<RealCart> cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");
                
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new RealCart { Product = _dbContext.Products.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        
        public IActionResult Remove(int id)
        {
            List<RealCart> cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");
            
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<RealCart> cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");
            
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        private IActionResult cartcount()
        {
            List<RealCart> cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");

            return RedirectToAction("Home", "Index");
        }


        public IActionResult AddToMyCart(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart") == null)
            {
                List<RealCart> cart = new List<RealCart>();
                cart.Add(new RealCart { Product = _dbContext.Products.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<RealCart> cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");

                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new RealCart { Product = _dbContext.Products.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index","Home");
        }


    }
}
