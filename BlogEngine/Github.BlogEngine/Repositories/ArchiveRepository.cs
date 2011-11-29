using System;
using System.Collections.Generic;
using Github.API;
using Github.API.Model;
using Github.BlogEngine.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Github.BlogEngine.Repositories
{
    // not used.. yet
    public class ArchiveRepository : Github.BlogEngine.Repositories.IArchiveRepository
    {
        private Adapter GitAdapter
        {
            get { return new Adapter(); }
        }
        private static CommitObject _lastCommit = null;
        private CommitObject LastCommit
        {
            get
            {
                return _lastCommit ?? GitAdapter.GetAllCommits(GitHubUserSettings.UserName, GitHubUserSettings.Repository,
                                                               GitHubUserSettings.Branch)[0];
            }
        }

        public IList<GitBaseObject> GetYearFolder()
        {
            var trees = GitAdapter.GetTrees(GitHubUserSettings.UserName, GitHubUserSettings.Repository, LastCommit.TreeSha);
            var rootObjects = Utilities.GetGitTreesByType(trees, "tree");
            return rootObjects;
        }

        public IList<GitBaseObject> GetMonthPostsFolder(string parentSha)
        {
            var trees = GitAdapter.GetTrees(GitHubUserSettings.UserName, GitHubUserSettings.Repository, parentSha);
            var subFolders = Utilities.GetGitTreesByType(trees,"tree");
            return subFolders;
        }    

        public IList<GitBaseObject> GetMonthPosts(string monthSha)
        {
            var files = GitAdapter.GetTrees(GitHubUserSettings.UserName, GitHubUserSettings.Repository, monthSha);
            var contentFiles = Utilities.GetGitTreeByMimeType(files, "text/html");
            return contentFiles;
        }

    }
}