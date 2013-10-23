using Nancy;
using OSSItPopular.Web.Support;

namespace OSSItPopular.Web.Modules
{
    public class NuGetModule : NancyModule
    {
        private readonly INuGetClient _nuGetClient;

        public NuGetModule(INuGetClient nuGetClient) : base("/nuget")
        {
            _nuGetClient = nuGetClient;

            Get["/package/{name}"] = p => _nuGetClient.GetPackageDetails(p.Name);
        }
    }
}