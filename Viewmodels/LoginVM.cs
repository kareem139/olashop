using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Viewmodels
{
    public class LoginVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
