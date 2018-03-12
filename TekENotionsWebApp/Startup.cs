using Microsoft.Owin;
using Owin;

using System.Web.Http;

[assembly: OwinStartup(typeof(TekENotionsWebApp.Authentication.Startup))]
namespace TekENotionsWebApp.Authentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}