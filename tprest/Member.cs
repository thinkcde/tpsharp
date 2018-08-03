using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// Member
    /// </summary>
    public class Member
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
        /// Get all Members of a Project
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Member> GetMembers(Project project, RestClient client)
        {
            dynamic data = client.ExecuteRequest(project.Url + "/members", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Member> pros = new List<Member>();
            foreach (var p in data["members"])
            {
                pros.Add(new Member() { Title = p["title"], Url = p["href"] });
            }
            return pros;
        }


        /// <summary>
        /// Get Member Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Member Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic projects = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = projects["member"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
