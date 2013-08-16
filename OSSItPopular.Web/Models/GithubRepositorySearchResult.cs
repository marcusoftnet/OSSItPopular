using System.Collections.Generic;

namespace OSSItPopular.Web.Models
{
    public class GithubRepositorySearchResult
    {
        public List<GithubRepository> Repositories { get; set; }
        public int NumberOfSearchResult { get; set; }

        public GithubRepositorySearchResult()
        {
        }

        public static GithubRepositorySearchResult Create(dynamic indata)
        {
            var result = new GithubRepositorySearchResult
            {
                NumberOfSearchResult = indata.total_count,
                Repositories = new List<GithubRepository>()
            };

            if (indata.items != null)
                foreach (var item in indata.items)
                    result.Repositories.Add(new GithubRepository { Id = item.id, Name = item.name });


            return result;
        }
    }
}