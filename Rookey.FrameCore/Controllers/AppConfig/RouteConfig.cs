using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Rookey.Frame.Common;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Rookey.Frame.Controllers.AppConfig
{
    /// <summary>
    /// 路由配置
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routes">路由集合</param>
        /// <param name="service"></param>
        public static void RegisterRoutes(IRouteBuilder routes, IServiceProvider service)
        {
            string defaultController = WebConfigHelper.GetAppSettingValue("DefaultController");
            string defaultAction = WebConfigHelper.GetAppSettingValue("DefaultAction");
            if (string.IsNullOrEmpty(defaultController))
                defaultController = "Page";
            if (string.IsNullOrEmpty(defaultAction))
                defaultAction = "Main";

            //自定义路由
            routes.Routes.Add(new LegacyRoute(service, defaultController, defaultAction, new string[] { "/" }));

            //默认路由
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}.html",
                defaults: new { controller = defaultController, action = defaultAction }
            );
        }
    }

    /// <summary>
    /// 自定义路由
    /// </summary>
    public class LegacyRoute : IRouter
    {
        private readonly string[] _urls;
        private readonly IRouter _mvcRoute;
        private readonly string _defaultController;
        private readonly string _defaultAction;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="services">service</param>
        /// <param name="defaultController">默认首页controller</param>
        /// <param name="defaultAction">默认首页action</param>
        /// <param name="urls">urls</param>
        public LegacyRoute(IServiceProvider services, string defaultController, string defaultAction, params string[] urls)
        {
            _urls = urls;
            _mvcRoute = services.GetRequiredService<MvcRouteHandler>();
            _defaultController = defaultController;
            _defaultAction = defaultAction;
        }

        /// <summary>
        /// 重写路由
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task RouteAsync(RouteContext context)
        {
            var requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (requestedUrl == string.Empty)
            {
                context.RouteData.Values["controller"] = _defaultController;
                context.RouteData.Values["action"] = _defaultAction;
            }
            return _mvcRoute.RouteAsync(context);
        }

        /// <summary>
        /// 生成对外显示的URL路径
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}