using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! DocumentFormDefinition
    /// </summary>
    public class DocumentFormDefinition
    {
        /// <summary>
        /// DocumentFormDefinition Title
        /// </summary>
        public string Title;

        /// <summary>
        /// DocumentFormDefinition Url
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
        /// Get all DocumentFormDefinitions
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<DocumentFormDefinition> GetDocumentFormDefinitions(Project project, RestClient client)
        {
            dynamic data = client.ExecuteRequest(project.Url + "/document_form_definitions", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<DocumentFormDefinition> pros = new List<DocumentFormDefinition>();
            foreach (var p in data["document_form_definitions"])
            {
                pros.Add(new DocumentFormDefinition() { Title = p["title"], Url = p["href"] });
            }
            return pros;
        }

        /// <summary>
        /// Get DocumentFormDefinition Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Project Details</returns>
        public IDictionary<string,object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["document_form_definition"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }


}
