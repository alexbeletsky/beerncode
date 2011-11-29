using System;
using System.Collections.Generic;
using Github.BlogEngine.Models;

namespace Github.BlogEngine.Repositories {
    public interface IArchiveRepository {
        IList<GitBaseObject> GetMonthPosts(string monthSha);
        IList<GitBaseObject> GetMonthPostsFolder(string parentSha);
        IList<GitBaseObject> GetYearFolder();
    }
}
