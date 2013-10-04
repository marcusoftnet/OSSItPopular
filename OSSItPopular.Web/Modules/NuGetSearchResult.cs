using System;
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
                        Authors = package.Authors,
                        Created = package.Created,
                        Published = package.Published,
                        IconUrl = package.IconUrl.ToString(),
                        ProjectUrl = package.ProjectUrl.ToString(),
                        TotalNumberOfDownloads = package.DownloadCount,
                        VersionNumberOfDownloads = package.VersionDownloadCount
                    });
            }

            return searchResult;
        }

        public IList<NuGetPackage> Packages { get; set; }
    }

    public class NuGetPackage
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime Created { get; set; }
        public DateTime Published { get; set; }
        public string ProjectUrl { get; set; }
        public string IconUrl { get; set; }
        public int VersionNumberOfDownloads { get; set; }
        public int TotalNumberOfDownloads { get; set; }
    }
}