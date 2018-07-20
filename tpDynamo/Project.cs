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
        /// Get all tp! Projects
        /// </summary>
        /// <param name="appKey">AppKey</param>
        /// <param name="baseUri">BaseUri</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>All tp! Projects for this user</returns>
        public static IEnumerable<thinkproject.Project> GetProjects(string appKey, string baseUri, string username, string password)
        {
            ApiConnection.Connect(appKey, baseUri, username, password);
            return thinkproject.Project.GetProjects(ApiConnection.GetConnection());
        }

        /// <summary>
        /// Get Project Info
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Project Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Project project)
        {
            var info = project.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// List tp! DocumentFormDefinitions
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Dictionary of DocumentFormDefinitions</returns>
        public static IEnumerable<thinkproject.DocumentFormDefinition> GetDocumentFormDefinitions(thinkproject.Project project)
        {
            return thinkproject.DocumentFormDefinition.GetDocumentFormDefinitions(project, ApiConnection.GetConnection());
        }

        /// <summary>
        /// List tp! Filters
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Dictionary of Filters</returns>
        public static IEnumerable<thinkproject.Filter> GetFilters(thinkproject.Project project)
        {
            return thinkproject.Filter.GetFilters(project, ApiConnection.GetConnection());
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
