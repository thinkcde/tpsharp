using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// Company
    /// </summary>
    public class Company
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
        /// Get all Companies of a Project
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Company> GetCompanies(Project project, RestClient client)
        {
            dynamic data = client.ExecuteRequest(project.Url + "/companies", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Company> pros = new List<Company>();
            foreach (var p in data["companies"])
            {
                pros.Add(new Company() { Title = p["title"], Url = p["href"] });
            }
            return pros;
        }


        /// <summary>
        /// Get Company Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Company Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["company"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
