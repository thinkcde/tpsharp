using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! Draft
    /// </summary>
    public class Draft
    {
        /// <summary>
        /// Draft Title
        /// </summary>
        public string Title;

        /// <summary>
        /// Draft Url
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
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="client"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="recipients_to"></param>
        /// <param name="recipients_cc"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Draft CreateDraft(Project project, RestClient client, string subject = null, string message = null, List<string> recipients_to = null, List<string> recipients_cc = null, String info = null)
        {
            Dictionary<string, object> draft = new Dictionary<string, object>();
            if (subject != null) draft.Add("subject", subject);
            if (message != null) draft.Add("message", message);
            if (recipients_to != null && !recipients_to.Any()) draft.Add("recipients_to", recipients_to);
            if (recipients_cc != null && !recipients_cc.Any()) draft.Add("recipients_cc", recipients_cc);
            if (info != null) draft.Add("info", info);

            dynamic data = client.ExecuteRequest(project.Url + "/drafts", RestSharp.Method.POST, SimpleJson.SimpleJson.SerializeObject(draft));

            return new Draft() { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentFormDefinition">tp! DocumentFormDefinition</param>
        /// <param name="client">tp! Rest Client</param>
        /// <param name="values"></param>
        public void AddDraftDocument(DocumentFormDefinition documentFormDefinition, RestClient client, Dictionary<string, object> values = null)
        {

        }

        /// <summary>
        /// This method gets all the attached draft documents, if there are any
        /// </summary>
        /// <returns>The attached draft documents</returns>
        public List<DraftDocument> GetDraftDocuments()
        {
            List<DraftDocument> draftDocuments = new List<DraftDocument>();
            return draftDocuments;
        }

        /// <summary>
        /// This method sends this draft with its attached draft documents, if there are any 
        /// </summary>
        public void SendDraft()
        {

        }

        public bool IsSent()
        {
            return false;
        }

        /// <summary>
        /// Get all Drafts from Project
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Draft> GetDrafts(Project project, RestClient client)
        {
            dynamic data = client.ExecuteRequest(project.Url + "/drafts", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Draft> drafts = new List<Draft>();
            foreach (var p in data["drafts"])
            {
                drafts.Add(new Draft() { Title = p["title"], Url = p["href"] });
            }
            return drafts;
        }


        /// <summary>
        /// Get Draft Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Draft Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic drafts = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = drafts["draft"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }


}

