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
            bool connected = ApiConnection.Connect(appKey, baseUri, username, password);
            if (!connected) throw new Exception(Properties.Resources.NoConnection);
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
        /// List tp! Members
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Dictionary of Filters</returns>
        public static IEnumerable<thinkproject.Member> GetMembers(thinkproject.Project project)
        {
            return thinkproject.Member.GetMembers(project, ApiConnection.GetConnection());
        }

        /// <summary>
        /// List tp! Companies
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Dictionary of Filters</returns>
        public static IEnumerable<thinkproject.Company> GetCompanies(thinkproject.Project project)
        {
            return thinkproject.Company.GetCompanies(project, ApiConnection.GetConnection());
        }

        /// <summary>
        /// List tp! Drafts
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Dictionary of Drafts</returns>
        public static IEnumerable<thinkproject.Draft> GetDrafts(thinkproject.Project project)
        {
            return thinkproject.Draft.GetDrafts(project, ApiConnection.GetConnection());
        }

        /// <summary>
        /// List tp! MemberList
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <returns>Dictionary of MemberLists</returns>
        public static IEnumerable<thinkproject.MemberList> GetMemberLists(thinkproject.Project project)
        {
            return thinkproject.MemberList.GetMemberLists(project, ApiConnection.GetConnection());
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
