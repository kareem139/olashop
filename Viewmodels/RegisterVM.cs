using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Viewmodels
{
    public class RegisterVM
    {

        public string UserName { get; set; }
        
        public string Email { get; set; }
        //[RegularExpression(@"[A-Z0-9a-z]")]
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string Role { get; set; }
    }
}
