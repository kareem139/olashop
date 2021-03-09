using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    public class FirstHomeController : Controller
    {
        public IActionResult FirstIndex()
        {
            return View();
        }
    }
}
