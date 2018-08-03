using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Document
    /// </summary>
    public static class Document
    {
        /// <summary>
        /// Get Document Info
        /// </summary>
        /// <param name="document">tp! Document</param>
        /// <returns>Document Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Document document)
        {
            var info = document.GetDetails(ApiConnection.GetConnection());
            return info;
        }

        /// <summary>
        /// Get Document Name
        /// </summary>
        /// <param name="document">tp! Document</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Document document)
        {
            return document.Title;
        }

        /// <summary>
        /// Get Document API Url
        /// </summary>
        /// <param name="document">tp! Document</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Document document)
        {
            return document.Url;
        }

    }
}
