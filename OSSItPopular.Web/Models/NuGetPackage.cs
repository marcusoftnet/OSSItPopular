using System;

namespace OSSItPopular.Web.Models
{
    public class NuGetPackage
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string Authors { get; set; }
        public DateTime Created { get; set; }
        public DateTime Published { get; set; }
        public string ProjectUrl { get; set; }
        public string IconUrl { get; set; }
        public int VersionNumberOfDownloads { get; set; }
        public int TotalNumberOfDownloads { get; set; }
        public string Url { get; set; }
    }
}