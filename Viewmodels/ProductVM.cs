using Microsoft.AspNetCore.Http;
using olashop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Viewmodels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public DateTime Adddate { get; set; }
        public int CategoryId { get; set; }
        public string BrandName { get; set; }
        public virtual List< Category> Category { get; set; }
        public virtual List<Brand> Brands { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string imgurl { get; set; }
    }
}
