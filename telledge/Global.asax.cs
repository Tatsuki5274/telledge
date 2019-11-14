using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace telledge
{
    // メモ: IIS6 または IIS7 のクラシック モードの詳細については、
    // http://go.microsoft.com/?LinkId=9394801 を参照してください
    // https://stackoverflow.com/questions/19777880/controller-with-same-name-as-an-area-asp-net-mvc4 を参考

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Student",
                "student/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "telledge.Controllers.Student" }
            );
            routes.MapRoute(
                "Default", // ルート名
                "{controller}/{action}/{id}", // パラメーター付きの URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // パラメーターの既定値
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}