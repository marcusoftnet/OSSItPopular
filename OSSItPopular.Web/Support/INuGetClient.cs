using OSSItPopular.Web.Models;

namespace OSSItPopular.Web.Support
{
    public interface INuGetClient
    {
        NuGetSearchResult GetPackageDetails(string packageName);
    }
}