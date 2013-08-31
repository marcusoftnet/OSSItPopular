using System;
using OSSItPopular.Web.Models;
using Should.Fluent;
using Xunit;

namespace OSSItPopular.Tests.Models
{
    public class when_parsing_a_detailed_result
    {
        private const string JSON = @"{'total_count':1,'items':[{'id':2284555,'name':'SpecFlow.Assist.Dynamic','full_name':'marcusoftnet/SpecFlow.Assist.Dynamic','owner':{'login':'marcusoftnet','id':184660,'avatar_url':'https://0.gravatar.com/avatar/38b83e237bba3d976eeab19e11fcdc3c?d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png','gravatar_id':'38b83e237bba3d976eeab19e11fcdc3c','url':'https://api.github.com/users/marcusoftnet','html_url':'https://github.com/marcusoftnet','followers_url':'https://api.github.com/users/marcusoftnet/followers','following_url':'https://api.github.com/users/marcusoftnet/following{/other_user}','gists_url':'https://api.github.com/users/marcusoftnet/gists{/gist_id}','starred_url':'https://api.github.com/users/marcusoftnet/starred{/owner}{/repo}','subscriptions_url':'https://api.github.com/users/marcusoftnet/subscriptions','organizations_url':'https://api.github.com/users/marcusoftnet/orgs','repos_url':'https://api.github.com/users/marcusoftnet/repos','events_url':'https://api.github.com/users/marcusoftnet/events{/privacy}','received_events_url':'https://api.github.com/users/marcusoftnet/received_events','type':'User'},'private':false,'html_url':'https://github.com/marcusoftnet/SpecFlow.Assist.Dynamic','description':'Extension methods to create dynamic objects from SpecFlow tables','fork':false,'url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic','forks_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/forks','keys_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/keys{/key_id}','collaborators_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/collaborators{/collaborator}','teams_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/teams','hooks_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/hooks','issue_events_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/issues/events{/number}','events_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/events','assignees_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/assignees{/user}','branches_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/branches{/branch}','tags_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/tags','blobs_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/git/blobs{/sha}','git_tags_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/git/tags{/sha}','git_refs_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/git/refs{/sha}','trees_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/git/trees{/sha}','statuses_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/statuses/{sha}','languages_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/languages','stargazers_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/stargazers','contributors_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/contributors','subscribers_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/subscribers','subscription_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/subscription','commits_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/commits{/sha}','git_commits_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/git/commits{/sha}','comments_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/comments{/number}','issue_comment_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/issues/comments/{number}','contents_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/contents/{+path}','compare_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/compare/{base}...{head}','merges_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/merges','archive_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/{archive_format}{/ref}','downloads_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/downloads','issues_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/issues{/number}','pulls_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/pulls{/number}','milestones_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/milestones{/number}','notifications_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/notifications{?since,all,participating}','labels_url':'https://api.github.com/repos/marcusoftnet/SpecFlow.Assist.Dynamic/labels{/name}','created_at':'2011-08-28T18:55:39Z','updated_at':'2013-08-01T19:09:01Z','pushed_at':'2013-07-27T17:21:46Z','git_url':'git://github.com/marcusoftnet/SpecFlow.Assist.Dynamic.git','ssh_url':'git@github.com:marcusoftnet/SpecFlow.Assist.Dynamic.git','clone_url':'https://github.com/marcusoftnet/SpecFlow.Assist.Dynamic.git','svn_url':'https://github.com/marcusoftnet/SpecFlow.Assist.Dynamic','homepage':'','size':14545,'watchers_count':10,'language':'C#','has_issues':true,'has_downloads':true,'has_wiki':true,'forks_count':5,'mirror_url':null,'open_issues_count':4,'forks':5,'open_issues':4,'watchers':10,'master_branch':'master','default_branch':'master','score':20.744093}]}";
        private GitHubRepositoryDetails parsedResult;

        public when_parsing_a_detailed_result()
        {
            parsedResult = GitHubRepositoryDetails.CreateFromJSON(JSON);
        }

        [Fact]
        public void score_should_been_parsed()
        {
            parsedResult.Score.Should().Equal(20.744093);
        }

        [Fact]
        public void numberOfWatchers_should_been_parsed()
        {
            parsedResult.NumberOfWatchers.Should().Equal(10);
        }

        [Fact]
        public void NumberOfOpenIssues_should_have_been_parsed()
        {
            parsedResult.NumberOfOpenIssues.Should().Equal(4);
        }

        [Fact]
        public void HasIssues_should_have_been_parsed()
        {
            parsedResult.HasIssues.Should().Equal(true);
        }

        [Fact]
        public void HasWiki_should_have_been_parsed()
        {
            parsedResult.HasWiki.Should().Equal(true);
        }

        [Fact]
        public void NumberOfForks_should_have_been_parsed()
        {
            parsedResult.NumberOfForks.Should().Equal(5);
        }

        [Fact]
        public void FullName_should_have_been_parsed()
        {
            parsedResult.FullName.Should().Equal("marcusoftnet/SpecFlow.Assist.Dynamic");
        }
    }
}
