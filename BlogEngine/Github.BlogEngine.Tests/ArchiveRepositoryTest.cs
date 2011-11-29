using System.Linq;
using Github.BlogEngine.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Github.BlogEngine.Models;

namespace Github.BlogEngine.Tests
{


    [TestClass()]
    public class ArchiveRepositoryTest
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
        public void ShouldHaveRootArchiveFolders()
        {
            var repository = new ArchiveRepository();
            var yearFolder = repository.GetYearFolder();
            Assert.IsTrue(yearFolder.Count > 0);
        }

        [TestMethod()]
        public void FirstYearFolderShouldHaveSubFolderOfMonthPosts()
        {
            var repository = new ArchiveRepository();
            var firstYear = repository.GetYearFolder().FirstOrDefault();
            Assert.IsNotNull(firstYear,"Could not load the first year folder from the repository");
            var monthPostsFolder = repository.GetMonthPostsFolder(firstYear.Sha);
            Assert.IsTrue(monthPostsFolder.Count > 0);
        }

        [TestMethod]
        public void FilesShouldBeReturned()
        {
            var repository = new ArchiveRepository();
            var firstYear = repository.GetYearFolder()[1];
            Assert.IsNotNull(firstYear, "Could not load the first year folder from the repository");
            var monthPostsFolder = repository.GetMonthPostsFolder(firstYear.Sha);

            var monthPosts = repository.GetMonthPosts(monthPostsFolder.First().Sha);
            Assert.IsNotNull(monthPosts);
            Assert.IsTrue(monthPosts.Count > 0);
        }
    }
}
