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
        /// <summary>
        /// tp Rest Connection
        /// </summary>
        public thinkproject.RestClient Connection;
    }

    /// <summary>
    /// tp! Api Nodes
    /// </summary>
    public static class API
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
    }
}
