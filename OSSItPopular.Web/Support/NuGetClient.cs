using OSSItPopular.Web.Models;
using RestSharp;

namespace OSSItPopular.Web.Support
{
    public class NuGetClient : INuGetClient
    {
        private readonly RestClient _client;
        private const string GET_PACKAGE_REQUEST_STRING = "/Packages()?$filter=substringof('{0}',Title)";

        public NuGetClient()
        {
            _client = new RestClient("https://www.nuget.org/api/v2");
        }

        private static IRestRequest CreateGetRequest(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            return request;
        }

        public NuGetSearchResult GetPackageDetails(string packageName)
        {
            var request = CreateGetRequest(string.Format(GET_PACKAGE_REQUEST_STRING, packageName));
            var json = _client.Execute(request).Content;
            return NuGetSearchResult.CreateFromJSon(json);
        }
    }
}