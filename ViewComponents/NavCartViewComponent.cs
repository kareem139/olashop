using Microsoft.AspNetCore.Mvc;
using olashop.Helpers;
using olashop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.ViewComponents
{
    public class NavCartViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                ViewBag.cart = "empty";
            }
            ViewBag.cart = cart;
            return View();
        }
    }
}
