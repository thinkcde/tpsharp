using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// Api Connection Wrapper
    /// </summary>
    [IsVisibleInDynamoLibrary(false)]
    public class ApiConnection
    {
        public thinkproject.RestClient Connection;
    }

    /// <summary>
    /// tp! Api Nodes
    /// </summary>
    public static class Nodes
    {
        /// <summary>
        /// Authenticate using credentials
        /// </summary>
        /// <param name="appKey">AppKey</param>
        /// <param name="baseUri">BaseUri</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>A tp! API connection</returns>
        public static ApiConnection Connect(string appKey, string baseUri, string username, string password)
        {
            thinkproject.RestClient rc = new thinkproject.RestClient(baseUri, appKey);
            rc.Authenticate(username, password);
            return new ApiConnection() { Connection = rc };
        }

        /// <summary>
        /// List tp! Projects
        /// </summary>
        /// <param name="connection">tp! Api Connection</param>
        /// <returns>Dictionary of projects</returns>
        public static IDictionary<string,object> ListProjects(ApiConnection connection)
        {
            return connection.Connection.Projects();
        }
    }
}
