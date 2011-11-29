using System.Collections.Generic;
using System.Linq;
using Github.API.Model;
using Github.BlogEngine.Models;

namespace Github.BlogEngine
{
    public static class Utilities
    {
        public static IList<GitBaseObject> GetGitTreesByType(IEnumerable<TreeObject> treeObjects, string type)
        {
            var trees = new List<GitBaseObject>();
            foreach (var treeObject in treeObjects.Where(t => t.Type == type))
            {
                if (IsArchiveFolder(treeObject))
                    trees.Add(new GitBaseObject { Name = treeObject.Name, Sha = treeObject.Sha });
            }
            return trees;
        }

        public static IList<GitBaseObject> GetGitTreeByMimeType(IEnumerable<TreeObject> treeObjects, string mimeType)
        {
            var baseObjects = new List<GitBaseObject>();
            foreach (var treeObject in treeObjects.Where(t => t.MimeType == mimeType))
                baseObjects.Add(new GitBaseObject{Name = treeObject.Name, Sha = treeObject.Sha});             
            return baseObjects;
        }

        //Return only the folders that have blog content.
        //Ex: 2010 or 05102010.
        //For more the structure of https://github.com/alexanderbeletsky/blog.beletsky.net
        public static bool IsArchiveFolder(TreeObject treeObject)
        {
            int i;
            return int.TryParse(treeObject.Name, out i);
        }


    }
}