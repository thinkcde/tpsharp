using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Filter
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// Get filter Info
        /// </summary>
        /// <param name="filter">tp! filter</param>
        /// <returns>Project Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Filter filter)
        {
            var info = filter.GetDetails(ApiConnection.GetConnection());
            return info;
        }

        /// <summary>
        /// Get Filter Name
        /// </summary>
        /// <param name="filter">tp! Filter</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Filter filter)
        {
            return filter.Title;
        }

        /// <summary>
        /// Get Filter API Url
        /// </summary>
        /// <param name="filter">tp! Filter</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Filter filter)
        {
            return filter.Url;
        }

        /// <summary>
        /// List tp! Documents
        /// </summary>
        /// <param name="filter">tp! Filter</param>
        /// <returns>Dictionary of Documents</returns>
        public static IEnumerable<thinkproject.Document> GetDocuments(thinkproject.Filter filter)
        {
            return thinkproject.Document.GetDocuments(filter, ApiConnection.GetConnection());
        }

        /// <summary>
        /// List tp! Communications
        /// </summary>
        /// <param name="filter">tp! Filter</param>
        /// <returns>Dictionary of Communications</returns>
        public static IEnumerable<thinkproject.Communication> GetCommunications(thinkproject.Filter filter)
        {
            return thinkproject.Communication.GetCommunications(filter, ApiConnection.GetConnection());
        }
    }
}
