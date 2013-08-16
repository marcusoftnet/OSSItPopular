using Nancy;
using OSSItPopular.Web.Support;

namespace OSSItPopular.Web.Modules
{
    public class GitHubModule : NancyModule
    {
        public GitHubModule(IGitHubClient client)
        {
            Get["/search"] = _ => client.SearchRepos(Request.Query.Name);
        }
    }
}