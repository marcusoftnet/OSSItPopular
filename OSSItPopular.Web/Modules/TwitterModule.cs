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
                string searchterm = parameters.Search;

                var result = (from search in CurrentTwitterContext.Search
                              where search.Type == SearchType.Search &&
                                    search.Query == searchterm
                              select search)
                            .SingleOrDefault();

                var resultList = result.Statuses.Select(
                    status => new TwitterSearchResult
                    {
                        ID = status.ID,
                        Link = status.Source,
                        CreatedAt = status.CreatedAt,
                        Text = status.Text
                    });

                return resultList.ToList();
            };
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
                        ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"],
                        ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"],
                        TwitterAccessToken = ConfigurationManager.AppSettings["twitterAccessToken"],
                        TwitterAccessTokenSecret = ConfigurationManager.AppSettings["twitterAccessTokenSecret"]
                    }
                };
            }
        }
    }
}