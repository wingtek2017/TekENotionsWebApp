using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Linq;

namespace TekENotionsWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            
            ////goes before the regular route
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);


            //HttpConfiguration config = GlobalConfiguration.Configuration;

            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
            //    Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //var jsonFormatter = config.Formatters
            //    .OfType<JsonMediaTypeFormatter>()
            //        .FirstOrDefault();
            //jsonFormatter.SerializerSettings
            //    .ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
