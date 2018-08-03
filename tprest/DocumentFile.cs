using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// DocumentFile
    /// </summary>
    public class DocumentFile
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
        /// Get all DocumentFiles from Document
        /// </summary>
        /// <param name="document">tp! Document</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<DocumentFile> GetDocumentFiles(Document document, RestClient client)
        {
            dynamic data = client.ExecuteRequest(document.Url + "/document_files", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<DocumentFile> documentFiles = new List<DocumentFile>();
            foreach (var p in data["document_files"])
            {
                documentFiles.Add(new DocumentFile() { Title = p["title"], Url = p["href"] });
            }
            return documentFiles;
        }

        /// <summary>
        /// Get DocumentFile Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>DocumentFile Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["document_file"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
