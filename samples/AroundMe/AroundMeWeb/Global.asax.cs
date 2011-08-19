// AroundMeApplication.cs
//

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AroundMeWeb {

    public class AroundMeApplication : HttpApplication {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");

            routes.MapRoute("DefaultRoute", "{controller}/{action}/{id}",
                            new {
                                controller = "Home",
                                action = "Index",
                                id = UrlParameter.Optional
                            });
        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
