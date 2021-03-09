using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using olashop.Data;
using olashop.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var res = _dbContext.Products.ToList();
           
            return View(res);
        }

     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult SearchWithCat(int id)
        {
            var res = _dbContext.Products.Where(r => r.CategoryId==id).ToList();
            return View("Search", res);

        }

        public IActionResult SearchWithPrice(int price)
        {
            var res = _dbContext.Products.Where(r => r.Price <= price).ToList();
            return View("Search", res);
        }

        public IActionResult QuickProductView(int id)
        {
            var pro = _dbContext.Products.FirstOrDefault(r => r.Id == id);

            ViewBag.pro = pro;
            return PartialView();
        }


        public IActionResult SearchNav(string word)
        {

           
            

         
             var res = _dbContext.Products.Where(r => r.Name.Contains(word) || r.Category.Name.Contains(word)).ToList();

         


            return View("Search", res);
        }
        //public IActionResult pop1()
        //{
        //    var p = _dbContext.Categories.Select(o => new KeyContent(o.Id, o.Name));

        //    return Json(p);
        //}

        //public IActionResult GetMealsSetValue(int[] categories)
        //{
        //    categories = categories ?? new int[] { };

        //    var items = _dbContext.Products.Where(o => categories.Contains(o.CategoryId)).ToList();

        //    object value = null;
        //    if (items.Any())
        //    {
        //        value = new[] { items.Skip(1).First().Id };
        //    }

        //    return Json(new AweItems
        //    {
        //        Items = items.Select(o => new KeyContent(o.Id, o.Name)),
        //        Value = value
        //    });
        //}
    }
}
