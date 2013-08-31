using System.Collections.Generic;
using Newtonsoft.Json;

namespace OSSItPopular.Web.Models
{
    public class GithubRepositorySearchResult
    {
        public List<GithubRepository> Repositories { get; set; }
        public int NumberOfSearchResult { get; set; }

        public static GithubRepositorySearchResult CreateFromJSON(string json)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            var result = new GithubRepositorySearchResult
            {
                NumberOfSearchResult = data.total_count,
                Repositories = new List<GithubRepository>()
            };

            if (data.items != null)
                foreach (var repo in data.items)
                    result.Repositories.Add(new GithubRepository
                        {
                            Id = repo.id,
                            Name = repo.name,
                            Url = repo.html_url,
                            FullName = repo.full_name
                        });


            return result;
        }
    }
}