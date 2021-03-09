using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.PayPal.Values
{
    public class ShippingPreference
    {

        /// <summary>
        /// Use the customer-provided shipping address on the PayPal site.
        /// </summary>
        public static string GET_FROM_FILE { get; private set; } = "GET_FROM_FILE";

        /// <summary>
        /// Redact the shipping address from the PayPal site. 
        /// Recommended for digital goods.
        /// </summary>
        public static string NO_SHIPPING { get; private set; } = "NO_SHIPPING";

        /// <summary>
        /// Use the merchant-provided address. 
        /// The customer cannot change this address on the PayPal site.
        /// </summary>
        public static string SET_PROVIDED_ADDRESS { get; private set; } = "SET_PROVIDED_ADDRESS";
    }
}
