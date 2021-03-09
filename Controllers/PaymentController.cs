using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using olashop.Helpers;
using olashop.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    public class PaymentController : Controller
    {
        private int amount = 100;
        private readonly ApplicationDbContext _dbContext;
        public PaymentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.PaymentAmount = amount;
            return View();
        }


        
        [HttpPost]
        [Authorize]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
           
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });
            var cart = SessionHelper.GetObjectFromJson<List< RealCart>>(HttpContext.Session, "cart");
            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount =cart.Sum(item=> item.Product.Price*item.Quantity),
                Description = "test pay",
                Currency = "usd",
                ReceiptEmail = stripeEmail,
                Customer=customer.Id,
                
                

            }) ;

            if (charge.Status== "succeeded")
            {
                string balancetransaction = charge.BalanceTransactionId;

              

                return RedirectToAction("Index", "Home");
            }

            //Dictionary<string, string> Metadata = new Dictionary<string, string>();
            //Metadata.Add("Product", "RubberDuck");
            //Metadata.Add("Quantity", "10");
            //var options = new ChargeCreateOptions
            //{
            //    Amount = amount,
            //    Currency = "USD",
            //    Description = "Buying 10 rubber ducks",
            //    Source = stripeToken,
            //    ReceiptEmail = stripeEmail,
            //    Metadata = Metadata
            //};
            //var service = new ChargeService();
            //Charge charge = service.Create(options);


            return RedirectToAction("Index","Cart");
        }
    }
}
