using Microsoft.AspNetCore.Mvc;
using olashop.Data;
//using Omu.AwesomeMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    public class PopupController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public PopupController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult pop1()
        //{
        //    var p = _dbContext.Categories.Select(o => new KeyContent(o.Id, o.Name));

        //    return Json(p);
        //}


        //public IActionResult pop2()
        //{
        //    var p = _dbContext.Categories.Select(o => new KeyContent(o.Id, o.Name));

        //    return Json(p);
        //}


    }
}
