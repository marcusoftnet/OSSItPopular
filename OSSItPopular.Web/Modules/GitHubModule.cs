using Nancy;
using OSSItPopular.Web.Support;

namespace OSSItPopular.Web.Modules
{
    public class GitHubModule : NancyModule
    {
        public GitHubModule(IGitHubClient client) : base("/github")
        {
            Get["/search"] = _ => client.SearchRepos(Request.Query.Name);
            Get["/stats/"] = _ => client.GetGitHubStats(Request.Query.FullName);
        }
    }
}