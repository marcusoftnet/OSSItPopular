using System.Collections.Generic;
using System.Configuration;
using OSSItPopular.Web.Models;
using RestSharp;

namespace OSSItPopular.Web.Support
{
    public class GitHubClient : IGitHubClient
    {
        private const string SEARCH_REQUEST_STRING = "/search/repositories?q={0}+in%3Aname&sort=stars";
        private const string DETAILS_REQUEST_STRING = "/search/repositories?q={0}+in%3Afull_name";
        private readonly RestClient _client;

        private static string OAuthToken { get { return ConfigurationManager.AppSettings["GitHubOAuthToken"]; } }

        public GitHubClient()
        {
            _client = new RestClient("https://api.github.com");
            _client.AddHandler("application/json", new DynamicJsonDeserializer());
            _client.Authenticator = new OAuth2UriQueryParameterAuthenticator(OAuthToken);
        }

        private static IRestRequest CreateGetRequest(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Accept", "application/vnd.github.preview");
            return request;
        }

        public GithubRepositorySearchResult SearchRepos(string searchString)
        {
            var request = CreateGetRequest(string.Format(SEARCH_REQUEST_STRING, searchString));
            var json = _client.Execute(request).Content;
            return GithubRepositorySearchResult.CreateFromJSON(json);
        }

        public GitHubRepositoryDetails GetGitHubStats(string fullName)
        {
            var request = CreateGetRequest(string.Format(DETAILS_REQUEST_STRING, fullName));
            var json = _client.Execute(request).Content;
            return GitHubRepositoryDetails.CreateFromJSON(json);
        }
    }
}