using Rookey.Frame.Controllers.Attr;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Rookey.Frame.Controllers.AppConfig
{
    /// <summary>
    /// 过滤配置
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 全局过滤配置
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(FilterCollection filters)
        {
            // ExceptionAttribute主要作用是将异常信息写入日志系统中
            filters.Add(new ExceptionAttribute());
        }
    }
}