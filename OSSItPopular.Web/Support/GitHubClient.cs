using System;
using OSSItPopular.Web.Models;
using RestSharp;

namespace OSSItPopular.Web.Support
{
    public class GitHubClient : IGitHubClient
    {
        private const string SEARCH_FORMAT_STRING = "/search/repositories?q={0}&sort=stars&order=desc";
        private readonly RestClient _client;
        private static string OAUTH_TOKEN = "268846e56751293fe10ef679485036da0b077608"; //TODO: Read from config

        public GitHubClient()
        {
            _client = new RestClient("https://api.github.com");
            _client.AddHandler("application/json", new DynamicJsonDeserializer());
            _client.Authenticator = new OAuth2UriQueryParameterAuthenticator(OAUTH_TOKEN);
        }

        public GithubRepositorySearchResult SearchRepos(string searchString)
        {
            var request = new RestRequest(string.Format(SEARCH_FORMAT_STRING, searchString), Method.GET);
            request.AddHeader("Accept", "application/vnd.github.preview");
            Console.WriteLine(_client.Execute(request).Content);
            var response = _client.Execute<dynamic>(request);

            var total = response.Data.total_count;

            return null;
        }
    }
}