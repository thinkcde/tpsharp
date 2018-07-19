using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! Project
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Project Title
        /// </summary>
        public string Title;

        /// <summary>
        /// Project Url
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
        /// Get all Projects
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Project> GetProjects(RestClient client)
        {
            dynamic projects = client.ExecuteRequest("/services/api/projects", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Project> pros = new List<Project>();
            foreach (var p in projects["projects"])
            {
                pros.Add(new Project() { Title = p["title"], Url = p["href"] });
            }
            return pros;
        }

        /// <summary>
        /// Get Project Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Project Details</returns>
        public IDictionary<string,object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            var data = projects["project"];
            return data;
        }
    }


}
