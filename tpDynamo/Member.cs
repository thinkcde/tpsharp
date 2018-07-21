using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! Member
    /// </summary>
    public static class Member
    {
        /// <summary>
        /// Get Member Info
        /// </summary>
        /// <param name="member">tp! Member</param>
        /// <returns>Member Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.Member member)
        {
            var info = member.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get Member Name
        /// </summary>
        /// <param name="member">tp! Member</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.Member member)
        {
            return member.Title;
        }

        /// <summary>
        /// Get Member API Url
        /// </summary>
        /// <param name="member">tp! Member</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.Member member)
        {
            return member.Url;
        }

    }
}
