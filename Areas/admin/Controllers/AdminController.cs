using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
