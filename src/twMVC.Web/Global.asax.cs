using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using twMVC.Interface;

namespace twMVC.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //Initial the ioc framework.
            InitIOC();

            //Set the controller factory to MVC.
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }

        private void InitIOC()
        {
            string refAssemblyName = "twMVC";
            var CastleWindsorContext = WindsorControllerFactory.Instance;

            //controller
            CastleWindsorContext
                .Register(
                    AllTypes.FromThisAssembly()
                        .BasedOn<IController>()
                        .If(t => t.Name.EndsWith("Controller"))
                        .Configure(a => a.LifestyleTransient())
                );

            //service
            CastleWindsorContext
                .Register(
                    AllTypes.FromAssemblyNamed(string.Concat(refAssemblyName, ".Services"))
                    .BasedOn<object>()
                    .If(t => t.Name.EndsWith("Service"))
                    .WithService.FirstInterface()
                    .Configure(a => a.LifestyleTransient())
                );

            //models
            CastleWindsorContext
                .Register(
                    AllTypes.FromAssemblyNamed(string.Concat(refAssemblyName, ".Models"))
                    .Where(a => true)
                    .WithService.FirstInterface()
                    .Configure(a => a.LifestyleTransient())
                );

            //repository
            CastleWindsorContext
                .Register(
                   AllTypes.FromAssemblyNamed(string.Concat(refAssemblyName, ".Repositories"))
                   .BasedOn(typeof(IRepository<>))
                   .WithService.FirstInterface()
                   .Configure(a => a.LifestyleTransient())
                );

        }
    }
}