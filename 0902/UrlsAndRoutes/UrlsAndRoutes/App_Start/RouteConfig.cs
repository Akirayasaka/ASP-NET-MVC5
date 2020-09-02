using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region [預設值]
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            #endregion

            #region [註冊路由]
            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);
            #endregion

            #region [使用MapRoute()方法來註冊路由]
            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "List"});
            #endregion

            #region [在URL模式內自定義額外變數]
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "DeafultId"});
            #endregion

            #region [定義URL參數(選填), 非必填 可空白或不填]
            // 不論是否有帶id欄位的值, 路由會進行自動比對
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catachall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional});
            #endregion

            #region [在路由中指定Namespace, 並解析順序(避免複數同名Controller存在時造成衝突)]
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new{ controller = "Home", action = "Index", id = UrlParameter.Optional},
            //    new[] { "URLsAndRoutes.AdditionalControllers" });
            #endregion

            #region [使用多重路由來掌握Namespace]
            //routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "URLsAndRoutes.AdditionalControllers" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional},
            //    new[] { "URLsAndRoutes.Controllers" });
            #endregion

            #region [限定在指定Controller內動作]
            //Route myRoute = routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "URLsAndRoutes.AdditionalControllers" });

            //myRoute.DataTokens["UseNamespaceFallback"] = false;
            #endregion

            #region [使用正則表達式來約束路由]
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = "^H.*" },
                new[] { "URLsAndRoutes.Controllers" });
            #endregion

            #region [設定指定值限制路由, 限制controller為H開頭 , action只能為 Index或是About, 其他action會報錯, 藉此建立精確的路由]
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "^H.*", action = "^Index$|^About$" },
            //    new[] { "URLsAndRoutes.Controllers" });
            #endregion

            #region [基於 HTTP Method 限制路由]
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "^H.*", action = "^Index$|^About$", httpMethod = new HttpMethodConstraint("GET")},
            //    new[] { "URLsAndRoutes.Controllers" });
            #endregion

            #region [使用內建的 型別/數值 限制]
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "^H.*", action = "Index|About", httpMethod = new HttpMethodConstraint("GET"), id = new RangeRouteConstraint(10, 20)},
            //    new[] { "URLsAndRoutes.Controllers" });
            #endregion
        }
    }
}
