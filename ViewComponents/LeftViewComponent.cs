using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.ViewComponents
{
    public class LeftViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public LeftViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var res = _dbContext.Products.ToList();
            return View(res);
        }

    }
}
