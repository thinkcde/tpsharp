using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! DocumentFile
    /// </summary>
    public static class DocumentFile
    {
        /// <summary>
        /// Get DocumentFile Info
        /// </summary>
        /// <param name="documentFile">tp! DocumentFile</param>
        /// <returns>DocumentFile Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.DocumentFile documentFile)
        {
            var info = documentFile.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get DocumentFile Name
        /// </summary>
        /// <param name="documentFile">tp! DocumentFile</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.DocumentFile documentFile)
        {
            return documentFile.Title;
        }

        /// <summary>
        /// Get DocumentFile API Url
        /// </summary>
        /// <param name="documentFile">tp! DocumentFile</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Communication documentFile)
        {
            return documentFile.Url;
        }

    }
}
