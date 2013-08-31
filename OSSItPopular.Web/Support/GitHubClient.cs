using System.Collections.Generic;
using System.Configuration;
using OSSItPopular.Web.Models;
using RestSharp;

namespace OSSItPopular.Web.Support
{
    public class GitHubClient : IGitHubClient
    {
        private const string SEARCH_REQUEST_STRING = "/search/repositories?q={0}+in%3Aname&sort=stars";
        private const string DETAILS_REQUEST_STRING = "/search?q=%40{0}&type=Repositories";
        private readonly RestClient _client;

        private static string OAuthToken { get { return ConfigurationManager.AppSettings["GitHubOAuthToken"]; } }

        public GitHubClient()
        {
            _client = new RestClient("https://api.github.com");
            _client.AddHandler("application/json", new DynamicJsonDeserializer());
            _client.Authenticator = new OAuth2UriQueryParameterAuthenticator(OAuthToken);
        }

        public GithubRepositorySearchResult SearchRepos(string searchString)
        {
            //var response = _client.Execute<dynamic>(CreateSearchRequest(searchString));
            var json = _client.Execute(CreateSearchRequest(searchString)).Content;


            return GithubRepositorySearchResult.CreateFromJSON(json);
                //{
                //    NumberOfSearchResult = response.Data.total_count,
                //    Repositories = ParseRepositories(response)
                //};

        }

        public GitHubRepositoryDetails GetGitHubStats(string fullName)
        {
            var response = _client.Execute(CreateDetailsRequest(fullName));

            return null;
        }

        private IRestRequest CreateDetailsRequest(string repositoryFullName)
        {
            var request = new RestRequest(string.Format(SEARCH_REQUEST_STRING, repositoryFullName), Method.GET);
            request.AddHeader("Accept", "application/vnd.github.preview");
            return request;
        }

        //private static List<GithubRepository> ParseRepositories(IRestResponse<dynamic> response)
        //{
        //    var repos = new List<GithubRepository>();
        //    foreach (var repo in response.Data.items)
        //        repos.Add(GithubRepositorySearchResult.Create()
        //            {
        //                Id = repo.id, Name = repo.full_name, Url = repo.html_url, FullName = repo.full_name
        //            });

        //    return repos;
        //}

        private static RestRequest CreateSearchRequest(string searchString)
        {
            var request = new RestRequest(string.Format(SEARCH_REQUEST_STRING, searchString), Method.GET);
            request.AddHeader("Accept", "application/vnd.github.preview");
            return request;
        }
    }
}