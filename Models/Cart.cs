using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using olashop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Models
{
    public class Cart
    {
        private readonly ApplicationDbContext _dbContext;
        private Cart(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Key]
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public  List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = service.GetService<ApplicationDbContext>();
            string cartid = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartid);
            return new Cart(context) { Id = cartid };
        }

        public void AddToCart(Product product,int Quantity)
        {
            var cartitem = _dbContext.CartItemss.SingleOrDefault(r => r.Product.Id == product.Id&& r.CartId==Id);
            if (cartitem==null)
            {
               
                cartitem = new CartItem
                {
                    CartId = Id,
                    Product = product,
                    Quantity = 1

                };
           
                
             
            
                _dbContext.CartItemss.Add(cartitem);

                
              

            }
            else
            {
                cartitem.Quantity++;
                _dbContext.CartItemss.Add(cartitem);
            }
            _dbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var cartitem = _dbContext.CartItemss.FirstOrDefault(r => r.Product.Id == product.Id && r.CartId == Id);

            var localquantity = 0;
            if (cartitem!=null)
            {
                if (cartitem.Quantity>1)
                {
                    cartitem.Quantity--;
                    localquantity = cartitem.Quantity;
                }
                else
                {
                    _dbContext.CartItemss.Remove(cartitem);

                }
            }
            _dbContext.SaveChanges();
            return localquantity;
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ?? (CartItems = _dbContext.CartItemss.Where(r => r.CartId == Id)
                .Include(r => r.Product).ToList()
                );
        }

        public void ClearCart()
        {
            var cartitems = _dbContext.CartItemss.Where(r => r.CartId == Id);
            _dbContext.CartItemss.RemoveRange(cartitems);
            _dbContext.SaveChanges();
        }

        public decimal GetCartTotalPrice()
        {
            var total = _dbContext.CartItemss.Where(r => r.CartId == Id).Select(r => r.Product.Price * r.Quantity).Sum();

            return total;
        }
    }
}
