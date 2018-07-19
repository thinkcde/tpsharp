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
    public static class Project
    {
        /// <summary>
        /// List tp! Projects
        /// </summary>
        /// <param name="connection">tp! Api Connection</param>
        /// <returns>Dictionary of projects</returns>
        public static IEnumerable<thinkproject.Project> GetProjects(ApiConnection connection)
        {
            return thinkproject.Project.GetProjects(connection.Connection);
        }

        /// <summary>
        /// Get Project Info
        /// </summary>
        /// <param name="connection">tp! Api Connection</param>
        /// <param name="project">tp! Project</param>
        /// <returns>Project Info</returns>
        public static IDictionary<string,object> GetInfo(ApiConnection connection, thinkproject.Project project)
        {
            return project.GetDetails(connection.Connection);
        }

        /// <summary>
        /// Get Project Name
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Project project)
        {
            return project.Title;
        }

        /// <summary>
        /// Get Project API Url
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Project project)
        {
            return project.Url;
        }

    }
}
