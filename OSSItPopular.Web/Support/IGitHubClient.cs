using OSSItPopular.Web.Models;

namespace OSSItPopular.Web.Support
{
    public interface IGitHubClient
    {
        GithubRepositorySearchResult SearchRepos(string searchString);
    }
}