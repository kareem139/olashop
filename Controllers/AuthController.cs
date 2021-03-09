using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using olashop.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login(string returnurl)
        {
            return View(new LoginVM { ReturnUrl = returnurl });
        }

        [HttpPost]
        
        public async Task< IActionResult> Login(LoginVM  vM)
        {
            if (!ModelState.IsValid)
            {
                return View(vM);
            }
            var user = await _userManager.FindByNameAsync(vM.UserName);
            if (user!=null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, vM.Password,false,false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(vM.ReturnUrl))
                    
                     return RedirectToAction("FirstIndex", "FirstHome");
                    return Redirect(vM.ReturnUrl);


                }
              
            }
            ModelState.AddModelError("", "not found");
            ViewBag.title = "error";
            ViewBag.message = "user or pass incorrect";
            return View(vM);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterVM vM)
        {
            var role = "Admin";
            vM.Role = role;
                
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = vM.UserName,
                    Email = vM.Email,
                    
                };
                var result = await _userManager.CreateAsync(user, vM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("FirstIndex", "FirstHome");
                }
            }
            return View(vM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("FirstIndex", "FirstHome");
        }
    }
}
