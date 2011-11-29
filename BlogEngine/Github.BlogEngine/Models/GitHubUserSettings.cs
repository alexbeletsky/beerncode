namespace Github.BlogEngine.Models
{
    public static class GitHubUserSettings
    {
        public static string UserName
        {
            get { return Properties.Settings.Default.GitUserName; }
        }

        public static string Repository
        {
            get { return Properties.Settings.Default.GitUserRepository; }
        }

        public static string Branch
        {
            get { return Properties.Settings.Default.GitRepositoryBranch; }
        }

        public static string TreeSha {
            get { return Properties.Settings.Default.TreeSha; } 
        }
    }
}