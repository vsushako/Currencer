using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebApplication1.Core
{
    public class DiControllerFactory : IControllerFactory
    {
        private string _controllerNamespace = "WebApplication1.Controllers";

        /// <summary>
        /// Внедряем зависимости в одном месте
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));
            if (controllerType == null)
                return null;

            var param = controllerType.GetConstructors()[0].GetParameters();
            if (param.Length == 0)
                return Activator.CreateInstance(controllerType) as IController;

            var models = param.Select(p => ModelFactory.GetModel(p.ParameterType)).ToList();
            return Activator.CreateInstance(controllerType, models.ToArray()) as IController;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}