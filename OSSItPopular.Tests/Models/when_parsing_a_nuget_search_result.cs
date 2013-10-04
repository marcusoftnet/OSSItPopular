using System;
using OSSItPopular.Web.Models;
using Xunit;

namespace OSSItPopular.Tests.Models
{
    public class when_parsing_a_nuget_search_result
    {
        private NuGetSearchResult _parsedResult;
        private NuGetPackage _package;
        private const string JSON = "{\"d\":{\"results\":[{\"__metadata\":{\"id\":\"https://www.nuget.org/api/v2/Packages(Id='ShouldFluent',Version='1.1.12.0')\",\"uri\":\"https://www.nuget.org/api/v2/Packages(Id='ShouldFluent',Version='1.1.12.0')\",\"type\":\"NuGetGallery.V2FeedPackage\",\"edit_media\":\"https://www.nuget.org/api/v2/Packages(Id='ShouldFluent',Version='1.1.12.0')/$value\",\"media_src\":\"https://www.nuget.org/api/v2/package/ShouldFluent/1.1.12.0\",\"content_type\":\"application/zip\"},\"Id\":\"ShouldFluent\",\"Version\":\"1.1.12.0\",\"Authors\":\"Tim Scott\",\"Copyright\":null,\"Created\":\"\\/Date(1294387219667)\\/\",\"Dependencies\":\"\",\"Description\":\"The Should Assertion Library provides a set of extension methods for test assertions for AAA and BDD style tests. It provides assertions only, and as a result it is Test runner agnostic. The assertions are a direct fork of the xUnit test assertions. This project was born because test runners Should be independent of the the assertions!\",\"DownloadCount\":11556,\"GalleryDetailsUrl\":\"https://www.nuget.org/packages/ShouldFluent/1.1.12.0\",\"IconUrl\":\"http://demo.com\",\"IsLatestVersion\":false,\"IsAbsoluteLatestVersion\":false,\"IsPrerelease\":false,\"Language\":null,\"LastUpdated\":\"\\/Date(1380812832803)\\/\",\"Published\":\"\\/Date(1294387220183)\\/\",\"PackageHash\":\"ZtipI9Si2CbQAOBG4THSZzPd50gM7qFLyRiQG5qlhS08aK9Xv2i+Vp/WYK+wfhkpVYZ3duo4PjbTc92ndBn4Dw==\",\"PackageHashAlgorithm\":\"SHA512\",\"PackageSize\":\"23576\",\"ProjectUrl\":\"http://demo2.com\",\"ReportAbuseUrl\":\"https://www.nuget.org/package/ReportAbuse/ShouldFluent/1.1.12.0\",\"ReleaseNotes\":null,\"RequireLicenseAcceptance\":false,\"Summary\":\"The Should Assertion Library provides a set of extension methods for test assertions for AAA and BDD style tests. It provides assertions only, and as a result it is Test runner agnostic. The assertions are a direct fork of the xUnit test assertions. This project was born because test runners Should be independent of the the assertions!\",\"Tags\":null,\"Title\":\"ShouldFluent\",\"VersionDownloadCount\":10130,\"MinClientVersion\":null,\"LastEdited\":null,\"LicenseUrl\":\"\",\"LicenseNames\":null,\"LicenseReportUrl\":null}]}}";

        public when_parsing_a_nuget_search_result()
        {
            _parsedResult = NuGetSearchResult.CreateFromJSon(JSON);
            _package = _parsedResult.Packages[0];
        }

        [Fact]
        public void result_list_contains_1_entity()
        {
            Assert.Equal(1, _parsedResult.Packages.Count);
        }

        [Fact]
        public void id_should_be_set()
        {
            Assert.Equal("ShouldFluent", _package.Id);
        }

        [Fact]
        public void title_should_be_set()
        {
            Assert.Equal("ShouldFluent", _package.Title);
        }

        [Fact]
        public void authors_should_be_set()
        {
            Assert.Equal("Tim Scott", _package.Authors);
        }

        [Fact]
        public void CreatedDate_should_be_set()
        {
            var expected = DateTime.Parse("2011-01-07");
            Assert.Equal(expected.Date, _package.Created.Date);
        }

        [Fact]
        public void PublishedDate_should_be_set()
        {
            var expected = DateTime.Parse("2011-01-07");
            Assert.Equal(expected.Date, _package.Published.Date);
        }

        [Fact]
        public void IconUrl_should_be_set()
        {
            Assert.Equal("http://demo.com", _parsedResult.Packages[0].IconUrl);
        }

        [Fact]
        public void TotalNumberOfDownloads_should_be_set()
        {
            Assert.Equal(11556, _parsedResult.Packages[0].TotalNumberOfDownloads);
        }

        [Fact]
        public void VersionNumberOfDownloads_should_be_set()
        {
            Assert.Equal(10130, _parsedResult.Packages[0].VersionNumberOfDownloads);
        }

        [Fact]
        public void ProjectUrl_should_be_set()
        {
            Assert.Equal("http://demo2.com", _parsedResult.Packages[0].ProjectUrl);
        }
    }
}
