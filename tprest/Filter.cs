using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// Filter
    /// </summary>
    public class Filter
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
        public static List<Filter> GetFilters(Project project, RestClient client)
        {
            dynamic data = client.ExecuteRequest(project.Url + "/filters", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Filter> pros = new List<Filter>();
            foreach (var p in data["filters"])
            {
                pros.Add(new Filter() { Title = p["title"], Url = p["href"] });
            }
            return pros;
        }

        /// <summary>
        /// Get Filter Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Filter Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["filter"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
