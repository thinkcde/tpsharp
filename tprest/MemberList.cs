using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! MemberList
    /// </summary>
    public class MemberList
    {

        /// <summary>
        /// MemberList Title
        /// </summary>
        public string Title;

        /// <summary>
        /// MemberList Url
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
        /// Get all MemberLists
        /// </summary>
        /// <param name="project">tp! Project</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<MemberList> GetMemberLists(Project project, RestClient client)
        {
            dynamic data = client.ExecuteRequest(project.Url + "/roles", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<MemberList> memberLists = new List<MemberList>();
            foreach (var p in data["role"])
            {
                memberLists.Add(new MemberList() { Title = p["title"], Url = p["href"] });
            }
            return memberLists;
        }


        /// <summary>
        /// Get MemberList Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>MemberList Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic memberLists = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = memberLists["role"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }

}

