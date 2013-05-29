using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;
using System.Web.Routing;

namespace twMVC.Web
{
    /// <summary>
    /// WindsorControllerFactory
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private static object _obj = new object();

        private static IWindsorContainer _Instance;
        public static IWindsorContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_obj)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new WindsorContainer();
                        }
                    }
                }
                return _Instance;
            }
        }

        private IWindsorContainer Container
        {
            get
            {
                return WindsorControllerFactory.Instance;
            }
        }

        public override void ReleaseController(IController controller)
        {
            this.Container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return Container.Resolve(controllerType) as IController;
        }
    }
}