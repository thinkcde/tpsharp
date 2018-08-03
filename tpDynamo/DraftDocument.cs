using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! DraftDocument
    /// </summary>
    public static class DraftDocument
    {
        /// <summary>
        /// Get Draft Document Info
        /// </summary>
        /// <param name="draftDocument">tp! DraftDocument</param>
        /// <returns>DraftDocument Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.DraftDocument draftDocument)
        {
            var info = draftDocument.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get DraftDocument Name
        /// </summary>
        /// <param name="draftDocument">tp! DraftDocument</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.DraftDocument draftDocument)
        {
            return draftDocument.Title;
        }

        /// <summary>
        /// Get DraftDocument API Url
        /// </summary>
        /// <param name="draftDocument">tp! DraftDocument</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.DraftDocument draftDocument)
        {
            return draftDocument.Url;
        }

    }
}
