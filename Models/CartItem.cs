using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public  Product Product { get; set; }
        public string CartId { get; set; }
    }
}
