using System.Collections.Generic;
using System.Net;
using Github.API.Model;
using Newtonsoft.Json;

namespace Github.API
{
    public class Adapter
    {
        private static readonly string ApiUrl = "http://github.com/api/v2/";

        private string GetDataFromGitHub(string url)
        {
            using (var webClient = new WebClient())
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                return webClient.DownloadString(url);
            }
        }

        public BlobsAll GetBlobAll(string username, string repo, string branch, string sha) {
            var url = string.Format("{0}json/blob/all/{1}/{2}/{3}", ApiUrl, username, repo, branch);

            return JsonConvert.DeserializeObject<BlobsAll>(GetDataFromGitHub(url));            
        }

        public BlobObject GetBlob(string username, string repository, string sha, string path)
        {
            var urlAddress = string.Format("{0}json/blob/show/{1}/{2}/{3}/{4}", ApiUrl, username, repository,
                                              sha, path);
            return JsonConvert.DeserializeObject<Blob>(GetDataFromGitHub(urlAddress)).BlobObject;
        }

        public IList<BlobObject> GetBlobs(string username, string repository, string sha)
        {
            var urlAddress = string.Format("{0}json/blob/full/{1}/{2}/{3}", ApiUrl, username, repository, sha);
            return JsonConvert.DeserializeObject<Blobs>(GetDataFromGitHub(urlAddress)).BlobObject;
        }

        public string GetBlobsRawData(string username, string repository, string sha)
        {
            var urlAddress = string.Format("{0}json/blob/show/{1}/{2}/{3}", ApiUrl, username, repository, sha);
            return GetDataFromGitHub(urlAddress);
        }

        public IList<CommitObject> GetAllCommits(string username, string repository, string branch)
        {
            var urlAddress = string.Format("{0}json/commits/list/{1}/{2}/{3}", ApiUrl, username, repository,
                                              branch);
            return JsonConvert.DeserializeObject<Commits>(GetDataFromGitHub(urlAddress)).CommitObjects;
        }

        public IList<TreeObject> GetTrees(string username, string repository, string treeSha)
        {
            var urlAddress = string.Format("{0}json/tree/show/{1}/{2}/{3}", ApiUrl, username, repository, treeSha);
            return JsonConvert.DeserializeObject<Trees>(GetDataFromGitHub(urlAddress)).TreeObjects;
        }
    }
}