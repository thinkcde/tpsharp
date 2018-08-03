using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! DraftDocument
    /// </summary>
    public class DraftDocument
    {

        /// <summary>
        /// DraftDocument Title
        /// </summary>
        public string Title;

        /// <summary>
        /// DraftDocument Url
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
        
        public void AddValues(Dictionary<string, object> values = null)
        {

        }

        /// <summary>
        /// Get all DraftDocuments
        /// </summary>
        /// <param name="draft">tp! Draft</param>
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
        /// Get DraftDocument Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>DraftDocument Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic draftdocuments = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = draftdocuments["draftdocument"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }



}
