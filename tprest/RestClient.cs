using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! Rest Client
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// Application Key
        /// </summary>
        private string AppKey;

        /// <summary>
        /// Base Uri (Instance information)
        /// </summary>
        private string BaseUri;

        /// <summary>
        /// RestClient
        /// </summary>
        private RestSharp.RestClient RClient;

        /// <summary>
        /// Auth Token
        /// </summary>
        private string Token;

        /// <summary>
        /// Check if client is authenticated
        /// </summary>
        public bool IsAuthenticated
        {
            get { return this.Token != string.Empty; }
        }

        /// <summary>
        /// Creates a new Rest Client for accessing tp! Api
        /// </summary>
        /// <param name="baseUri">BaseUri (including instance path)</param>
        /// <param name="appKey">AppKey</param>
        public RestClient(string baseUri, string appKey)
        {
            this.BaseUri = baseUri;
            this.AppKey = appKey;
            this.RClient = new RestSharp.RestClient(BaseUri);
        }

        /// <summary>
        /// Exectute a REST Request
        /// </summary>
        /// <param name="path">Api path</param>
        /// <param name="method">Request Method</param>
        /// <param name="token">Optional: Token</param>
        /// <param name="body">Optional: Body object</param>
        /// <returns>Json Dictionary</returns>
        public SimpleJson.JsonObject ExecuteRequest(string path, RestSharp.Method method, object body = null)
        {
            try
            {
                string restpath = (path.StartsWith(BaseUri)) ? path : String.Format("{0}{1}", BaseUri, path);
                var request = new RestSharp.RestRequest(restpath, method);
                request.AddHeader("X-TP-APPLICATION-CODE", AppKey);
                request.AddHeader("Content-Type", "application/json");
                if (this.Token != string.Empty) request.AddHeader("Authorization", String.Format("Bearer {0}",this.Token));
                request.RequestFormat = RestSharp.DataFormat.Json;
                if (body != null) request.AddBody(body);
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                var response = RClient.Execute(request);
                return SimpleJson.SimpleJson.DeserializeObject(response.Content) as SimpleJson.JsonObject;
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// Authenticate first
        /// </summary>
        /// <param name="user">Username</param>
        /// <param name="pass">Password</param>
        public void Authenticate(string user, string pass)
        {
            var response = ExecuteRequest("/services/api/auth", RestSharp.Method.POST, new { username = user, password = pass });
            if (response != null && response.ContainsKey("token")) this.Token = response["token"].ToString();
        }


    }
}
