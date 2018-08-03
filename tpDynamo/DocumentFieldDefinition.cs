using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! DocumentFieldDefinition
    /// </summary>
    public static class DocumentFieldDefinition
    {
        /// <summary>
        /// Get DocumentFieldDefinition Info
        /// </summary>
        /// <param name="documentFieldDefinition">tp! DocumentFieldDefinition</param>
        /// <returns>DocumentFieldDefinition Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.DocumentFieldDefinition documentFieldDefinition)
        {
            var info = documentFieldDefinition.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get DocumentFieldDefinition Name
        /// </summary>
        /// <param name="documentFieldDefinition">tp! DocumentFieldDefinition</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.DocumentFieldDefinition documentFieldDefinition)
        {
            return documentFieldDefinition.Title;
        }

        /// <summary>
        /// Get DocumentFieldDefinition API Url
        /// </summary>
        /// <param name="documentFieldDefinition">tp! DocumentFieldDefinition</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.DocumentFieldDefinition documentFieldDefinition)
        {
            return documentFieldDefinition.Url;
        }

    }
}
