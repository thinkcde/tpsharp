using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! Communication
    /// </summary>
    public class Communication
    {

        /// <summary>
        /// Communication Title
        /// </summary>
        public string Title;

        /// <summary>
        /// Communication Url
        /// </summary>
        public string Url;

        /// <summary>
        /// ToString Override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Title;
        }

        /// <summary>
        /// Get all Communications
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Draft> GetDraftDocuments(Draft draft, RestClient client)
        {
            dynamic data = client.ExecuteRequest(draft.Url + "/draftdocuments", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Draft> drafts = new List<Draft>();
            foreach (var p in data["draftdocuments"])
            {
                drafts.Add(new Draft() { Title = p["title"], Url = p["href"] });
            }
            return drafts;
        }


        /// <summary>
        /// Get Communication Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Communication Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic communications = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = communications["communication"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }

}

