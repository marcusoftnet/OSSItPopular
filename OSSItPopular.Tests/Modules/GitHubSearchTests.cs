using System.Collections.Generic;
using FakeItEasy;
using Nancy.Testing;
using OSSItPopular.Web.Models;
using OSSItPopular.Web.Modules;
using OSSItPopular.Web.Support;
using Should.Fluent;
using Xunit;

namespace OSSItPopular.Tests.Modules
{
    public class GitHubSearchTests
    {
        [Fact]
        public void ShouldSearchRepositoriesByName()
        {
            // Arrange
            var fakeGitHubClient = A.Fake<IGitHubClient>();
            var searchString = "NancyFx";
            A.CallTo(() => fakeGitHubClient.SearchRepos(searchString)).Returns(
                new GithubRepositorySearchResult
                {
                    NumberOfSearchResult = 3,
                    Repositories = new List<GithubRepository> {
                            new GithubRepository {Id = "1", Name = searchString + "1"},
                            new GithubRepository {Id = "2", Name = searchString + "2"},
                            new GithubRepository {Id = "3", Name = searchString + "3"},
                        }
                });
            
            var browser = new Browser(with =>
                {
                    with.Module<GitHubModule>();
                    with.Dependency<IGitHubClient>(fakeGitHubClient);
                });

            // Act
            var response = browser.Get("/search", ctx =>
                { 
                    ctx.Query("name", searchString);
                    ctx.Header("Accept", "application/json");
                })
                .Body.DeserializeJson<GithubRepositorySearchResult>();
            
            // Assert
            response.NumberOfSearchResult.Should().Equal(3);

        }
    }
}

