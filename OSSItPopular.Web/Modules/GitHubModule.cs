using Nancy;
using OSSItPopular.Web.Support;

namespace OSSItPopular.Web.Modules
{
    public class GitHubModule : NancyModule
    {
        public GitHubModule(IGitHubClient client)
        {
            Get["/search"] = _ =>
                {
                    var name = Request.Query.Name;
                    return client.SearchRepos(name);
                };
        }
    }
}