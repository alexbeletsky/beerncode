using System.Configuration;
using System.Net;
using Github.API.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Github.API.Tests
{
    [TestClass()]
    public class AdapterTest
    {
        private string username;
        private string repository;
        private string treeSha;
        private string branch;

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        [TestInitialize()]
        public void TestInitialize()
        {
            username = ConfigurationManager.AppSettings["username"];
            repository = ConfigurationManager.AppSettings["repository"];
            treeSha = ConfigurationManager.AppSettings["tree_sha"];
            branch = ConfigurationManager.AppSettings["branch"];

        }
        #endregion

        [TestMethod()]
        [DeploymentItem("Github.API.dll")]
        public void GetBlobShouldReturnAValidValue()
        {
            var target = new Adapter();
            string path = "2011/02022011/ValGardenTrip.htm";
            //string path = "Linkedin/Summary.htm";

            var actual = target.GetBlob(username, repository, treeSha, path);

            Assert.IsTrue(actual.Data != null);
            Assert.AreEqual((string)actual.MimeType, "text/html");
        }

        [TestMethod()]
        [DeploymentItem("Github.API.dll")]
        public void GetAllCommitsShouldReturnAListOfCommits()
        {
            var target = new Adapter();
            var actual = target.GetAllCommits(username, repository, branch);

            Assert.IsTrue(actual.Count > 0);
        }

        [TestMethod()]
        public void GetTreesShouldReturnAListOfTrees()
        {
            var target = new Adapter();
            var actual = target.GetTrees(username, repository, treeSha);

            Assert.IsTrue(actual.Count > 0);
        }

        [TestMethod]
        public void GetBlobsRawDataShouldReturnADataString()
        {
            var adapter = new Adapter();
            string sha = "fedbe8bd68dfd8d320dc2f486f1db3afb8d8ba13";
            var result = adapter.GetBlobsRawData(username, repository, sha);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GetPost() {
            var treeSha = "74d474ba69c0ee98229342b34ce9ac48a58869bc";
            var adapter = new Adapter();

            var results = adapter.GetBlobs(username, repository, treeSha);
        }

        [TestMethod]
        public void GetBlobAll() {
            var adapter = new Adapter();
            var blobAll = adapter.GetBlobAll(username, repository, branch,treeSha);

            var r =  blobAll.GetHtmlFiles();
        }

    }
}
