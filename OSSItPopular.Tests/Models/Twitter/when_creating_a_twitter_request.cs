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

        private TwitterClient _twitterClient;

        public when_creating_a_twitter_request()
        {
            _twitterClient = new TwitterClient();
        }

        [Fact]
        public void the_key_and_secret_should_be_URL_encoded()
        {
            // Arrange
            var key = "ö123";
            var secret = "321ö";

            // Act
            var encoded = _twitterClient.GetOAuthKey(key, secret);

            // Assert
            Assert.Equal("JWMzJWI2MTIzOjMyMSVjMyViNg==", encoded);
        }


        [Fact]
        public void the_key_and_secret_should_be_base64_encoding()
        {
            // Arrange
            var key = "123";
            var secret = "321";

            // Act
            var encoded = _twitterClient.GetOAuthKey(key, secret);

            // Assert
            Assert.Equal("MTIzOjMyMQ==", encoded);
        }

    }

    public class TwitterClient
    {
        public string GetOAuthKey(string key, string secret)
        {
            var urlEndcodedKey = HttpUtility.UrlEncode(key);
            var urlEndcodedSecret = HttpUtility.UrlEncode(secret);

            var concatenated = string.Format("{0}:{1}", urlEndcodedKey, urlEndcodedSecret);

            return Base64Encode(concatenated);
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
