using Newtonsoft.Json;

namespace OSSItPopular.Web.Models
{
    public class GitHubRepositoryDetails
    {
        public static GitHubRepositoryDetails CreateFromJSON(string json)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(json).items[0]; //HACK: Voj voj - this is a bit ugly
            
            return new GitHubRepositoryDetails
                {
                    FullName =  data.full_name,
                    Score = data.score,
                    NumberOfWatchers = data.watchers_count,
                    NumberOfOpenIssues = data.open_issues_count,
                    HasIssues = data.has_issues,
                    NumberOfForks = data.forks,
                    HasWiki = data.has_wiki
                };

        }

        public int NumberOfForks { get; set; }
        public double Score { get; set; }
        public int NumberOfWatchers { get; set; }
        public bool HasIssues { get; set; }
        public bool HasWiki { get; set; }
        public int NumberOfOpenIssues { get; set; }

        public string FullName { get; set; }
    }
}