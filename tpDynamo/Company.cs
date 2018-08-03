using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Company
    /// </summary>
    public static class Company
    {
        /// <summary>
        /// Get Company Info
        /// </summary>
        /// <param name="company">tp! company</param>
        /// <returns>Company Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Company company)
        {
            var info = company.GetDetails(ApiConnection.GetConnection());
            return info;
        }

        /// <summary>
        /// Get Company Name
        /// </summary>
        /// <param name="company">tp! Company</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Company company)
        {
            return company.Title;
        }

        /// <summary>
        /// Get Company API Url
        /// </summary>
        /// <param name="company">tp! Company</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Company company)
        {
            return company.Url;
        }

    }
}
