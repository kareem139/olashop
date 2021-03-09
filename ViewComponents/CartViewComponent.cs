using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using olashop.Helpers;
using olashop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.ViewComponents
{
    public class CartViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public CartViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      

        public IViewComponentResult Invoke()
        {
            var cart = SessionHelper.GetObjectFromJson<List<RealCart>>(HttpContext.Session, "cart");
            if (cart==null)
            {
                ViewBag.count = 0;
                
            }
            else
            {
                
                int final = 0;
                foreach (var item in cart)
                {
                    final = final + item.Quantity;
                };
                ViewBag.count = final;
            }
            
            return View();

        }
    }
}
