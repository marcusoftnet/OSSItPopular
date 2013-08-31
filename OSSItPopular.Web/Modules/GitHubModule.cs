using Nancy;
using OSSItPopular.Web.Support;

namespace OSSItPopular.Web.Modules
{
    public class GitHubModule : NancyModule
    {
        public GitHubModule(IGitHubClient client) : base("/GitHub")
        {
            Get["/search"] = _ => client.SearchRepos(Request.Query.Name);
            Get["/Stats/{Id}"] = parameters => client.GetGitHubStats(parameters.Id);
        }
    }
}