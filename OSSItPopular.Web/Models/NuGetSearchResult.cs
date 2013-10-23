using System.Collections.Generic;
using Newtonsoft.Json;

namespace OSSItPopular.Web.Models
{
    public class NuGetSearchResult
    {
        public NuGetSearchResult()
        {
            Packages = new List<NuGetPackage>();
        }

        public static NuGetSearchResult CreateFromJSon(string json)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            var searchResult = new NuGetSearchResult();
            foreach (var package in data.d.results)
            {
                searchResult.Packages.Add(new NuGetPackage
                {
                    Id = package.Id,
                    Title = package.Title,
                    Version = package.Version,
                    Authors = package.Authors,
                    Created = package.Created,
                    Published = package.Published,
                    IconUrl = package.IconUrl.ToString(),
                    ProjectUrl = package.ProjectUrl.ToString(),
                    TotalNumberOfDownloads = package.DownloadCount,
                    VersionNumberOfDownloads = package.VersionDownloadCount,
                    Url = package.GalleryDetailsUrl,
                });
            }

            searchResult.MoreThanOneResult = searchResult.Packages.Count > 1;

            return searchResult;
        }

        public IList<NuGetPackage> Packages { get; set; }
        public bool MoreThanOneResult { get; set; }
    }
}