using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Address
    /// </summary>
    public static class Address
    {
        /// <summary>
        /// Get Address Info
        /// </summary>
        /// <param name="address">tp! Address</param>
        /// <returns>Address Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Address address)
        {
            var info = address.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get Address Name
        /// </summary>
        /// <param name="address">tp! Address</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Address address)
        {
            return address.Title;
        }

        /// <summary>
        /// Get Address API Url
        /// </summary>
        /// <param name="address">tp! Address</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Address address)
        {
            return address.Url;
        }

    }
}
