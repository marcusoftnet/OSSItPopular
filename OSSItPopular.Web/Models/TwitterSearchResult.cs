using System;

namespace OSSItPopular.Web.Models
{
    public class TwitterSearchResult
    {
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
    }
}