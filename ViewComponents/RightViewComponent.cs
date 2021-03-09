using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.ViewComponents
{
    public class RightViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public RightViewComponent(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(_dbContext.Categories.ToList());
        }
    }
}
