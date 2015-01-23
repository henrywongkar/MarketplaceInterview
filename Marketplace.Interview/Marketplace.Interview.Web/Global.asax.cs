using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Marketplace.Interview.Business.Core;
using Marketplace.Interview.Web;
using Marketplace.Interview.Web.IoC;

namespace Marketplace.Interview.Web
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : ObjectFactory.GetObject<IController>(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            ObjectFactory.Release(controller);
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectFactory.WindsorContainer.Install(new WindsorInstaller());

            ControllerBuilder.Current.SetControllerFactory(typeof(WindsorControllerFactory));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}