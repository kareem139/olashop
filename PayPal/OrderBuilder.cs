using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.PayPal
{
    public class OrderBuilder
    {

        /// <summary>
        /// Use classes from the PayPalCheckoutSdk to build an OrderRequest
        /// </summary>
        /// <returns></returns>
        public static OrderRequest Build()
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",

                ApplicationContext = new ApplicationContext
                {
                    BrandName = "EXAMPLE INC",
                    LandingPage = "BILLING",
                    UserAction = "CONTINUE",
                    ShippingPreference = "SET_PROVIDED_ADDRESS"
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
        {
          new PurchaseUnitRequest{
            ReferenceId =  "PUHF",
            Description = "Sporting Goods",
            CustomId = "CUST-HighFashions",
            SoftDescriptor = "HighFashions",
            AmountWithBreakdown = new AmountWithBreakdown
            {
              CurrencyCode = "USD",
              Value = "230.00",
              AmountBreakdown = new AmountBreakdown
              {
                ItemTotal = new Money
                {
                  CurrencyCode = "USD",
                  Value = "180.00"
                },
                Shipping = new Money
                {
                  CurrencyCode = "USD",
                  Value = "30.00"
                },
                Handling = new Money
                {
                  CurrencyCode = "USD",
                  Value = "10.00"
                },
                TaxTotal = new Money
                {
                  CurrencyCode = "USD",
                  Value = "20.00"
                },
                ShippingDiscount = new Money
                {
                  CurrencyCode = "USD",
                  Value = "10.00"
                }
              }
            },
            Items = new List<Item>
            {
              new Item
              {
                Name = "T-shirt",
                Description = "Green XL",
                Sku = "sku01",
                UnitAmount = new Money
                {
                  CurrencyCode = "USD",
                  Value = "90.00"
                },
                Tax = new Money
                {
                  CurrencyCode = "USD",
                  Value = "10.00"
                },
                Quantity = "1",
                Category = "PHYSICAL_GOODS"
              },
              new Item
              {
                Name = "Shoes",
                Description = "Running, Size 10.5",
                Sku = "sku02",
                UnitAmount = new Money
                {
                  CurrencyCode = "USD",
                  Value = "45.00"
                },
                Tax = new Money
                {
                  CurrencyCode = "USD",
                  Value = "5.00"
                },
                Quantity = "2",
                Category = "PHYSICAL_GOODS"
              }
            },
            ShippingDetail = new ShippingDetail
            {
              Name = new Name
              {
                FullName = "John Doe"
              },
              AddressPortable = new AddressPortable
              {
                AddressLine1 = "123 Townsend St",
                AddressLine2 = "Floor 6",
                AdminArea2 = "San Francisco",
                AdminArea1 = "CA",
                PostalCode = "94107",
                CountryCode = "US"
              }
            }
          }
        }
            };



            return orderRequest;
        }
    }
}
