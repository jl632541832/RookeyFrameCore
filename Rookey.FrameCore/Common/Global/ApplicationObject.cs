using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Rookey.Frame.Common
{
    /// <summary>
    /// 全局对象
    /// </summary>
    public static class ApplicationObject
    {
        private static HttpContext _currentOneHttpContext;

        /// <summary>
        /// 当前任意一个上下文对象，此对象不可用于获取用户缓存信息
        /// </summary>
        public static HttpContext CurrentOneHttpContext
        {
            get { return _currentOneHttpContext; }
            set { _currentOneHttpContext = value; }
        }

        /// <summary>
        /// 获取httpContext对象
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static HttpContext GetHttpContext(HttpRequest request)
        {
            if (request != null)
            {
                return request.HttpContext;
            }
            return null;
        }

        /// <summary>
        /// 获取当前程序进程ID
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentProcessId()
        {
            return Process.GetCurrentProcess().Id.ToString();
        }

        /// <summary>
        /// 获取当前线程ID
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentThreadId()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
        }

        /// <summary>
        /// 执行SQL超时时间设置
        /// </summary>
        public static int Sql_CommandTimeout = 120;

        /// <summary>
        /// 执行批处理超时时间设置
        /// </summary>
        public static int Sql_TSCommandTimeout = 120;
    }
}
