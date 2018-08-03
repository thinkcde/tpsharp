using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace tpDynamo
{
    /// <summary>
    /// tp! MemberList
    /// </summary>
    public static class MemberList
    {
        /// <summary>
        /// Get MemberList Info
        /// </summary>
        /// <param name="memberList">tp! MemberList</param>
        /// <returns>MemberList Info</returns>
        public static IDictionary<string,object> GetInfo(thinkproject.MemberList memberList)
        {
            var info = memberList.GetDetails(ApiConnection.GetConnection());
            Type t = info.GetType();
            return info;
        }

        /// <summary>
        /// Get MemberList Name
        /// </summary>
        /// <param name="memberList">tp! MemberList</param>
        /// <returns>Name</returns>
        public static string GetName(thinkproject.MemberList memberList)
        {
            return memberList.Title;
        }

        /// <summary>
        /// Get MemberList API Url
        /// </summary>
        /// <param name="memberList">tp! MemberList</param>
        /// <returns>Url</returns>
        public static string GetUrl(thinkproject.MemberList memberList)
        {
            return memberList.Url;
        }

    }
}
