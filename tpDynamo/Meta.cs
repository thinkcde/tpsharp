using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Meta Information
    /// </summary>
    public static class Meta
    {
        /// <summary>
        /// Get Instance Info
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Instance Info</returns>
        public static IDictionary<string,object> GetInstance(thinkproject.Project project)
        {
            var info = thinkproject.Meta.GetInstance(ApiConnection.GetConnection());
            return info;
        }

        /// <summary>
        /// Get Product Info
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Product Info</returns>
        public static IDictionary<string, object> GetProduct(thinkproject.Project project)
        {
            var info = thinkproject.Meta.GetProduct(ApiConnection.GetConnection());
            return info;
        }
    }
}
