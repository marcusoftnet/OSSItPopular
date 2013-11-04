using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using LinqToTwitter;
using Nancy;
using OSSItPopular.Web.Models;

namespace OSSItPopular.Web.Modules
{
    public class TwitterModule : NancyModule
    {

        public TwitterModule()
        {
            Get["/twitter/{search}"] = parameters =>
            {
                var result = SearchTwitter(parameters.Search);

                return ParseIntoTwitterResultEntities(result).ToList();
            };
        }

        private static IEnumerable<TwitterSearchResult> ParseIntoTwitterResultEntities(Search result)
        {
            return result.Statuses.Select(
                status => new TwitterSearchResult
                {
                    ID = status.ID,
                    Link = status.Source,
                    CreatedAt = status.CreatedAt,
                    Text = status.Text
                });
        }

        private Search SearchTwitter(string searchterm)
        {
            return (from search in CurrentTwitterContext.Search
                where search.Type == SearchType.Search &&
                      search.Query == searchterm
                select search)
                .SingleOrDefault();
        }

        private TwitterContext _twitterContext;

        private TwitterContext CurrentTwitterContext
        {
            get { return _twitterContext ?? (_twitterContext = new TwitterContext(Authorizer)); }
        }

        private SingleUserAuthorizer Authorizer
        {
            get
            {
                return new SingleUserAuthorizer
                {
                    Credentials = new SingleUserInMemoryCredentials
                    {
                        ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"],
                        ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"],
                        TwitterAccessToken = ConfigurationManager.AppSettings["TwitterAccessToken"],
                        TwitterAccessTokenSecret = ConfigurationManager.AppSettings["TwitterAccessTokenSecret"]
                    }
                };
            }
        }
    }
}