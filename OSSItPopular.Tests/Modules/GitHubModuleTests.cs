using System.Collections.Generic;
using FakeItEasy;
using Nancy.Testing;
using OSSItPopular.Web.Models;
using OSSItPopular.Web.Modules;
using OSSItPopular.Web.Support;
using Xunit;
using Should.Fluent;

namespace OSSItPopular.Tests.Modules
{
    public class GitHubModuleTests
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
            var response = browser.Get("/github/search", ctx =>
                { 
                    ctx.Query("name", searchString);
                    ctx.Header("Accept", "application/json");
                })
                .Body.DeserializeJson<GithubRepositorySearchResult>();
            
            // Assert
            response.NumberOfSearchResult.Should().Equal(3);

        }

        [Fact]
        public void ShouldReturnDetailsAboutRepository()
        {
            // Arrange
            var fakeGitHubClient = A.Fake<IGitHubClient>();
            var fullName = "marcusoftnet/SpecFlow.Assist.Dynamic";
            A.CallTo(() => fakeGitHubClient.GetGitHubStats(fullName)).Returns(
                new GitHubRepositoryDetails()
                {
                    HasIssues = true,
                    HasWiki = true,
                    NumberOfForks = 2,
                    NumberOfOpenIssues = 2,
                    NumberOfWatchers = 2,
                    FullName = fullName
                });

            var browser = new Browser(with =>
            {
                with.Module<GitHubModule>();
                with.Dependency<IGitHubClient>(fakeGitHubClient);
            });

            // Act
            var response = browser.Get("/github/stats/", ctx =>
            {
                ctx.Query("fullName", fullName);
                ctx.Header("Accept", "application/json");
            })
            .Body.DeserializeJson<GitHubRepositoryDetails>();

            // Assert
            response.FullName.Should().Equal(fullName);
            response.HasWiki.Should().Equal(true);
            response.HasIssues.Should().Equal(true);
            response.NumberOfForks.Should().Equal(2);
            response.NumberOfOpenIssues.Should().Equal(2);
            response.NumberOfWatchers.Should().Equal(2);

        }
    }
}

