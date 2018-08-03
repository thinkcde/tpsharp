using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Draft
    /// </summary>
    public static class Draft
    {
        /// <summary>
        /// Get Draft Info
        /// </summary>
        /// <param name="draft">tp! Draft</param>
        /// <returns>Draft Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Draft draft)
        {
            var info = draft.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get Draft Name
        /// </summary>
        /// <param name="draft">tp! Draft</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Draft draft)
        {
            return draft.Title;
        }

        /// <summary>
        /// Get Draft API Url
        /// </summary>
        /// <param name="draft">tp! Draft</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Draft draft)
        {
            return draft.Url;
        }

    }
}
