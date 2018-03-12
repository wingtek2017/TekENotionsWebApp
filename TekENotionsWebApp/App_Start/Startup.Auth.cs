using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TekENotionsWebApp.Providers;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp
{
    public partial class Startup
    {

    }
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        HttpConfiguration config = new HttpConfiguration();

    //        ConfigureOAuth(app);

    //        WebApiConfig.Register(config);
    //        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
    //        app.UseWebApi(config);
    //    }

    //    // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
    //    public void ConfigureOAuth(IAppBuilder app)
    //    {
    //        OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
    //        {
    //            AllowInsecureHttp =  true,
    //            TokenEndpointPath = new PathString("/token"),
    //            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
    //            Provider = new SimpleAuthorizationServerProvider()
    //        };

    //        app.UseOAuthAuthorizationServer(OAuthServerOptions);
    //        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions())
    //            ;
    //    }
    //}
}
// Uncomment the following lines to enable logging in with third party login providers
        //app.UseMicrosoftAccountAuthentication(
        //    clientId: "",
        //    clientSecret: "");

        //app.UseTwitterAuthentication(
        //    consumerKey: "",
        //    consumerSecret: "");

        //app.UseFacebookAuthentication(
        //    appId: "",
        //    appSecret: "");

        //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //{
        //    ClientId = "",
        //    ClientSecret = ""
        //});
    


