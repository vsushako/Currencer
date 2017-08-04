using System.Configuration;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Microsoft.Owin;
using Owin;
using WebApplication1.Core;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Service;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var controllerFactory = new DiControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            int requestInterval;
            int.TryParse(ConfigurationManager.AppSettings["RateRequest.Interval"], out requestInterval);

            // Если запускать не через делегаты, то получатся все модели будут жить с одним инстансом, что не есть гуд
            // Можно было бы через using создавать модели + сделать фабрику моделей, что бы уйти от new
            new GetCurrencyJob(requestInterval, () =>
            {
                var dataModel = new DataModel();
                var rateModel = new RateModel(dataModel);
                var currencyModel = new CurrencyModel(dataModel);
                var rateGetter = new YahooapisRateGetter(new HttpHelper());
                var currencyChecker = new CurrencyChecker(currencyModel, rateModel, rateGetter);
                currencyChecker.GetCurrensies();
            }).Start();
        }
    }
}
