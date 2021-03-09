using olashop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Viewmodels
{
    public class CategoryVM
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
