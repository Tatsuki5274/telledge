using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace telledge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス

            // Web API ルート
            config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "SectionApi",
				routeTemplate: "api/sections/",
				defaults: new { controller = "sections"}
			);
			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
