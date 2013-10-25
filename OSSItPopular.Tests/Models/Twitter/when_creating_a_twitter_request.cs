using Nancy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OSSItPopular.Tests.Models.Twitter
{
    public class when_creating_a_twitter_request
    {
        private const string KEY = "1234567890";
        private const string SECRET = "0987654321";
        private TwitterClient _twitterClient;

        public when_creating_a_twitter_request()
        {
            _twitterClient = new TwitterClient();
        }

        [Fact]
        public void the_key_and_secret_should_be_URL_encoded_and_concatenated_with_colon()
        {
            var urlEncoded = _twitterClient.GetOAuthKey(KEY, SECRET);

            Assert.Equal("1234567890:0987654321", urlEncoded);
        }
        //consumer key and the consumer secret 
    }

    public class TwitterClient
    {
        public string GetOAuthKey(string key, string secret)
        {
            var urlEndcodedKey = HttpUtility.UrlEncode(key);
            var urlEndcodedSecret = HttpUtility.UrlEncode(secret);

            return string.Format("{0}:{1}", urlEndcodedKey, urlEndcodedSecret);
        }
    }
}
