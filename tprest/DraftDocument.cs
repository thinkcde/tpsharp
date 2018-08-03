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
        /// Get all DraftDocuments from Draft
        /// </summary>
        /// <param name="draft">tp! Draft</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<DraftDocument> GetDraftDocuments(Draft draft, RestClient client)
        {
            dynamic data = client.ExecuteRequest(draft.Url + "/draft_documents", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<DraftDocument> draftDocuments = new List<DraftDocument>();
            foreach (var p in data["draft_documents"])
            {
                draftDocuments.Add(new DraftDocument() { Title = p["title"], Url = p["href"] });
            }
            return draftDocuments;
        }


        /// <summary>
        /// Get DraftDocument Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>DraftDocument Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic draftdocuments = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = draftdocuments["draft_document"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }



}
