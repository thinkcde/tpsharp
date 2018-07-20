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

        [TestMethod]
        public void ProjectsTest()
        {
            thinkproject.RestClient c = new thinkproject.RestClient(Properties.Settings.Default.BaseUri, Properties.Settings.Default.AppKey);
            c.Authenticate(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            var p = thinkproject.Project.GetProjects(c);
            Assert.IsNotNull(p);
        }


        [TestMethod]
        public void DFDTest()
        {
            thinkproject.RestClient c = new thinkproject.RestClient(Properties.Settings.Default.BaseUri, Properties.Settings.Default.AppKey);
            c.Authenticate(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            var p = thinkproject.Project.GetProjects(c);
            var dfd = thinkproject.DocumentFormDefinition.GetDocumentFormDefinitions(p[0], c);
            Assert.IsNotNull(dfd);
        }

        [TestMethod]
        public void FilterTest()
        {
            thinkproject.RestClient c = new thinkproject.RestClient(Properties.Settings.Default.BaseUri, Properties.Settings.Default.AppKey);
            c.Authenticate(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            var p = thinkproject.Project.GetProjects(c);
            var dfd = thinkproject.Filter.GetFilters(p[0], c);
            Assert.IsNotNull(dfd);
        }

        [TestMethod]
        public void DocumentTest()
        {
            thinkproject.RestClient c = new thinkproject.RestClient(Properties.Settings.Default.BaseUri, Properties.Settings.Default.AppKey);
            c.Authenticate(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            var p = thinkproject.Project.GetProjects(c);
            var dfd = thinkproject.Filter.GetFilters(p[0], c);
            var docs = thinkproject.Document.GetDocuments(dfd[6], c);
            Assert.IsNotNull(docs);
        }
    }
}
