using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Communication
    /// </summary>
    public static class Communication
    {
        /// <summary>
        /// Get Communication Info
        /// </summary>
        /// <param name="communication">tp! Communications</param>
        /// <returns>Communication Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Communication communication)
        {
            var info = communication.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get Communication Name
        /// </summary>
        /// <param name="communication">tp! Communication</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Communication communication)
        {
            return communication.Title;
        }

        /// <summary>
        /// Get Communication API Url
        /// </summary>
        /// <param name="communication">tp! Communication</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Communication communication)
        {
            return communication.Url;
        }

    }
}
