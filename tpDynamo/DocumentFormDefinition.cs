using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Project
    /// </summary>
    public static class DocumentFormDefinition
    {
        /// <summary>
        /// Get DocumentFormDefinition Info
        /// </summary>
        /// <param name="definition">tp! DocumentFormDefinition</param>
        /// <returns>Project Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.DocumentFormDefinition definition)
        {
            var info = definition.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get DocumentFormDefinition Name
        /// </summary>
        /// <param name="definition">tp! DocumentFormDefinition</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.DocumentFormDefinition definition)
        {
            return definition.Title;
        }

        /// <summary>
        /// Get DocumentFormDefinition API Url
        /// </summary>
        /// <param name="definition">tp! DocumentFormDefinition</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.DocumentFormDefinition definition)
        {
            return definition.Url;
        }

        /// <summary>
        /// List tp! Filters
        /// </summary>
        /// <param name="definition">tp! DocumentFormDefinition</param>
        /// <returns>Dictionary of Filters</returns>
        public static IEnumerable<thinkproject.Filter> GetFilters(thinkproject.DocumentFormDefinition definition)
        {
            return thinkproject.Filter.GetFilters(definition, ApiConnection.GetConnection());
        }

    }
}
