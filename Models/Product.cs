using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public DateTime Adddate { get; set; }
        public int CategoryId { get; set; }
        public string BrandName { get; set; }
        public  Category Category { get; set; }
        public Brand Brand { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
