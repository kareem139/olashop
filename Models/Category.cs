using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
