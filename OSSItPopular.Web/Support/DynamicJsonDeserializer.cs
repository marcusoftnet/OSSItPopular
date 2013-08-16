using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace OSSItPopular.Web.Support
{
    public class DynamicJsonDeserializer : IDeserializer
    {
        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
    }
}