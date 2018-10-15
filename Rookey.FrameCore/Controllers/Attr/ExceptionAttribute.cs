using Microsoft.AspNetCore.Mvc.Filters;
using Rookey.Frame.Operate.Base;
using System;
using System.Linq;
using System.Text;

namespace Rookey.Frame.Controllers.Attr
{
    /// <summary>
    /// 异常处理特性
    /// </summary>
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 触发异常时调用的方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            //参数
            StringBuilder strParams = new StringBuilder();
            if (filterContext.HttpContext!=null && filterContext.HttpContext.Request != null
                && filterContext.HttpContext.Request.QueryString != null )
            {
                var paramCollection = filterContext.HttpContext.Request.Query;
                foreach (string oneParam in paramCollection.Keys)
                {
                    try
                    {
                        strParams.AppendFormat("{0}={1},", oneParam, paramCollection[oneParam]);
                    }
                    catch (Exception ex)
                    {
                        strParams.AppendFormat("{0}=获得参数值异常,{1}", oneParam, ex.Message);
                    }
                }
            }
            LogOperate.AddExceptionLog(filterContext.Exception, strParams.ToString(), filterContext.RouteData.Values["controller"].ToString(), filterContext.RouteData.Values["action"].ToString());
            base.OnException(filterContext);
        }
    }
}
