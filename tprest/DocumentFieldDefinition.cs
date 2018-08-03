using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// DocumentFieldDefinition
    /// </summary>
    public class DocumentFieldDefinition
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
        /// Get all DocumentFieldDefinitions from DocumentFormDefinition
        /// </summary>
        /// <param name="documentFormDefinition">tp! DocumentFormDefinition</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<DocumentFieldDefinition> GetDocumentFieldDefinitions(DocumentFormDefinition documentFormDefinition, RestClient client)
        {
            dynamic data = client.ExecuteRequest(documentFormDefinition.Url + "/document_field_definitions", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<DocumentFieldDefinition> documentFieldDefinitions = new List<DocumentFieldDefinition>();
            foreach (var p in data["document_field_definitions"])
            {
                documentFieldDefinitions.Add(new DocumentFieldDefinition() { Title = p["title"], Url = p["href"] });
            }
            return documentFieldDefinitions;
        }

        /// <summary>
        /// Get DocumentFieldDefinition Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>DocumentFieldDefinition Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["document_field_definition"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
