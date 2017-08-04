using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using WebApplication1.Core;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = UrlParameter.Optional }
            );

            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));
        }
    }
}