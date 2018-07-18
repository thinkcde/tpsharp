using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace thinkproject
{
    [TestClass]
    public class RestTests
    {
        [TestMethod]
        public void AuthTest()
        {
            thinkproject.RestClient c = new thinkproject.RestClient(Properties.Settings.Default.BaseUri, Properties.Settings.Default.AppKey);
            c.Authenticate(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            Assert.IsTrue(c.IsAuthenticated);
        }
    }
}
