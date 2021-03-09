using Microsoft.AspNetCore.Mvc;
using olashop.Helpers;
using olashop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.ViewComponents
{
    public class PaymentViewComponent:ViewComponent
    {
        
       

        public IViewComponentResult Invoke()
        {
            var cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");

            ViewBag.PaymentAmount = cart.Sum(item => item.Product.Price * item.Quantity); 
            return View();
        }
    }
}
