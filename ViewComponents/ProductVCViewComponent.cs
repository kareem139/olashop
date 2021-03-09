using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.ViewComponents
{
    public class ProductVCViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductVCViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke(int id)
        {
            var pro = _dbContext.Products.FirstOrDefault(item => item.Id == id);
            ViewBag.pro = pro;
            return View();
        }
    }
}
