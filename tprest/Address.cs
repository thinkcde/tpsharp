using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkproject
{
    /// <summary>
    /// tp! Address
    /// </summary>
    public class Address
    {

        /// <summary>
        /// Address Title
        /// </summary>
        public string Title;

        /// <summary>
        /// Address Url
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
        /// Get all Addresses from Member
        /// </summary>
        /// <param name="member">tp! Member</param>
        /// <param name="client">tp! Rest Client</param>
        /// <returns></returns>
        public static List<Address> GetAddresses(Member member, RestClient client)
        {
            dynamic data = client.ExecuteRequest(member.Url + "/addresses", RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            List<Address> addresses = new List<Address>();
            foreach (var p in data["address"])
            {
                addresses.Add(new Address() { Title = p["title"], Url = p["href"] });
            }
            return addresses;
        }


        /// <summary>
        /// Get Address Details
        /// </summary>
        /// <param name="client">tp! Rest Client</param>
        /// <returns>Address Details</returns>
        public IDictionary<string, object> GetDetails(RestClient client)
        {
            dynamic addresses = client.ExecuteRequest(this.Url, RestSharp.Method.GET).ToDictionary(p => p.Key, p => p.Value);
            SimpleJson.JsonObject data = addresses["address"];
            return data.ToDictionary(p => p.Key, p => p.Value);
        }
    }

}

