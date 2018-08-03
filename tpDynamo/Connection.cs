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
    public static class ApiConnection
    {
        /// <summary>
        /// tp Rest Connection Singleton
        /// </summary>
        private static thinkproject.RestClient Connection;

        /// <summary>
        /// Get tp! API Connection
        /// </summary>
        /// <returns>Api Connection</returns>
        [IsVisibleInDynamoLibrary(false)]
        public static thinkproject.RestClient GetConnection()
        {
            if (Connection == null)
                throw new Exception(Properties.Resources.NoAPI);
            else
                return Connection;
        }

        /// <summary>
        /// Connect to Tp API
        /// </summary>
        /// <param name="appKey">AppKey</param>
        /// <param name="baseUri">BaseUri</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        [IsVisibleInDynamoLibrary(false)]
        public static bool Connect(string appKey, string baseUri, string username, string password)
        {
            try
            {
                Connection = new thinkproject.RestClient(baseUri, appKey);
                Connection.Authenticate(username, password);
                return Connection.IsAuthenticated;
            }
            catch (Exception e) { return false; }
        }
    }

   
}
