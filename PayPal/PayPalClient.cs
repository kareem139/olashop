using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using PayPalCheckoutSdk.Core;
using System.Text;
using System.IO;
namespace olashop.PayPal
{
    public class PayPalClient
    {
        // Place these static properties into a settings area.
        public static string SandboxClientId { get; set; } =
                          "<alert>{PayPal SANDBOX Client Id}</alert>";
        public static string SandboxClientSecret { get; set; } =
                             "<alert>{PayPal SANDBOX Client Secret}</alert>";

        public static string LiveClientId { get; set; } =
                      "<alert>{PayPal LIVE Client Id}</alert>";
        public static string LiveClientSecret { get; set; } =
                      "<alert>{PayPal LIVE Client Secret}</alert>";

        ///<summary>
        /// Set up PayPal environment with sandbox credentials.
        /// In production, use LiveEnvironment.
        ///</summary>
        public static PayPalEnvironment Environment()
        {
#if DEBUG
            // You may want to create a UAT (user exceptance tester) 
            // role and check for this:
            // "if(_unitOfWork.IsUATTester(GetUserId())" instead of fcomiler directives.
            return new SandboxEnvironment(
                "AWU3Y0fr37AIC6VhumD32Ea0gHHhA3noBVT1bKFuAGcfHDi6zQVLovfEsjXI6txtY4hFjyGbgP5sB2oh",
                "EBzJVFQqne8Rzoc6Df7Q7rp6_fRBILtolfDO75ck2u7OVSgWKV9kfYafqyW8rMsN942mWl24CyWgeId8"
                                          );
#else
            return new LiveEnvironment(<alert>LiveClientId</alert>, 
                                       <alert>LiveClientSecret</alert>);
#endif
        }

        ///<summary>
        /// Returns PayPalHttpClient instance to invoke PayPal APIs.
        ///</summary>
        public static PayPalCheckoutSdk.Core.PayPalHttpClient Client()
        {
            return new PayPalHttpClient(Environment());
        }

        public static PayPalCheckoutSdk.Core.PayPalHttpClient Client(string refreshToken)
        {
            return new PayPalHttpClient(Environment(), refreshToken);
        }

        ///<summary>
        /// Use this method to serialize Object to a JSON string.
        ///</summary>
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(memoryStream,
                                                                  Encoding.UTF8,
                                                                  true,
                                                                  true,
                                                                  "  ");

            var ser = new DataContractJsonSerializer(serializableObject.GetType(),
                                                 new DataContractJsonSerializerSettings
                                                 {
                                                     UseSimpleDictionaryFormat = true
                                                 });

            ser.WriteObject(writer,
                            serializableObject);

            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);

            return sr.ReadToEnd();
        }
    }
}
