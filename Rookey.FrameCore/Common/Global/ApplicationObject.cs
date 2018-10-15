using System;
using System.Collections.Generic;
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
    }
}
