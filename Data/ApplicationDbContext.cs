using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using olashop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace olashop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Cartss { get; set; }
        public DbSet<CartItem> CartItemss { get; set; }
    }
}
