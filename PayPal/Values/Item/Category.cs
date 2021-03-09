using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.PayPal.Values.Item
{
    public class Category
    {
        /// Goods that are stored, delivered, and
        /// used in their electronic format.
        /// This value is not currently supported for API callers that leverage the
        /// [PayPal for Commerce Platform]
        /// (https://www.paypal.com/us/webapps/mpp/commerce-platform) product.
        /// </summary>
        public static string DIGITAL_GOODS { get; private set; } = "DIGITAL_GOODS";

        /// <summary>
        /// A tangible item that can be shipped with proof of delivery.
        /// </summary>
        public static string PHYSICAL_GOODS { get; private set; } = "PHYSICAL_GOODS";
    }
}
