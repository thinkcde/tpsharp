using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// Meta Info
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Get Product Information
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static Dictionary<string,object> GetProduct(RestClient client)
        {
            dynamic data = client.ExecuteRequest("/services/api/product", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            return data;
        }

        /// <summary>
        /// Get Instance Information
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetInstance(RestClient client)
        {
            dynamic data = client.ExecuteRequest("/services/api/instance", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            return data;
        }

    }
}
