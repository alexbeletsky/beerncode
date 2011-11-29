using System.Linq;
using Github.BlogEngine.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Github.BlogEngine.Models;
using System.Collections.Generic;

namespace Github.BlogEngine.Tests
{
    [TestClass()]
    public class PostRepositoryTest
    {


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
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void GetAllPostsShouldReturnAListOfPosts()
        {
            PostRepository target = new PostRepository(); // TODO: Initialize to an appropriate value
            var allPosts = target.GetAllPosts();
            string title = allPosts.First().Title;

            Assert.IsTrue(allPosts.Count > 0);
        }
    }
}
