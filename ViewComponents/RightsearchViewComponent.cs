using olashop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace  olashop.ViewComponents
{
    public class RightsearchViewComponent:ViewComponent
    {
            private readonly ApplicationDbContext _context;

            public RightsearchViewComponent(ApplicationDbContext context)
            {
                _context = context;
            }

            public IViewComponentResult Invoke()
            {
                return View();
            }
    }
}