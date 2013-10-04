using System.Linq;
using OSSItPopular.Web.Support;
using Xunit;

namespace OSSItPopular.Tests.Models
{
    public class NuGetClientTests
    {
        [Fact]
        public void should_get_package_results_for_1_known_package_name()
        {
            // Arrange
            var packageName = "ShouldFluent";
            var client = new NuGetClient();

            // Act
            var packageResult = client.GetPackageDetails(packageName);

            // Assert
            Assert.Equal(1, packageResult.Packages.Count);
            Assert.Equal(packageName, packageResult.Packages[0].Title);
        }

        [Fact]
        public void should_get_package_results_with_many_hits()
        {
            // Arrange
            var packageName = "Should";
            var client = new NuGetClient();

            // Act
            var packageResult = client.GetPackageDetails(packageName);

            // Assert
            Assert.True(packageResult.Packages.Count > 1);
            Assert.True(packageResult.Packages.All(p => p.Title.Contains(packageName)));
        }
    }

    
}
