using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApplication1.Core
{
    public class ServiceActivator : IHttpControllerActivator
    {
        public ServiceActivator(HttpConfiguration configuration) { }

        public IHttpController Create(HttpRequestMessage request
            , HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var param = controllerType.GetConstructors()[0].GetParameters();
            if (param.Length == 0)
                return Activator.CreateInstance(controllerType) as IHttpController;

            var models = param.Select(p => ModelFactory.GetModel(p.ParameterType)).ToList();
            return Activator.CreateInstance(controllerType, models.ToArray()) as IHttpController;
        }
    }
}