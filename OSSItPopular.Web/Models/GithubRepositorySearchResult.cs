using System.Collections.Generic;

namespace OSSItPopular.Web.Models
{
    public class GithubRepositorySearchResult
    {
        public List<GithubRepository> Repositories { get; set; }
        public int NumberOfSearchResult { get; set; }
    }
}