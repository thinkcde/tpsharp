using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// Document
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Url
        /// </summary>
        public string Url;

        /// <summary>
        /// Title
        /// </summary>
        public string Title;

        /// <summary>
        /// ToString Override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Title;
        }

        /// <summary>
        /// Get all DocumentFormDefinitions
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Document> GetDocuments(Filter filter, RestClient client)
        {
            dynamic data = client.ExecuteRequest(filter.Url + "/documents", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Document> pros = new List<Document>();
            foreach (var p in data["documents"])
            {
                pros.Add(new Document() { Title = p["title"], Url = p["href"] });
            }
            return pros;
        }

        /// <summary>
        /// Get Document Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Document Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["document"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
