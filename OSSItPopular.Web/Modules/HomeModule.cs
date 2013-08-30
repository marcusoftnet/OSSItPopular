using Nancy;

namespace OSSItPopular.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Index.html"];
        }
    }
}