/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookey.Frame.Base;
using Rookey.Frame.Base.User;
using Rookey.Frame.Common;
using Rookey.Frame.Controllers.Attr;
using System.Collections.Generic;
using System.Linq;

namespace Rookey.Frame.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [PermissionFilter]
    public class BaseController : Controller
    {
        private HttpRequest _Request = null; //请求对象

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request">请求对象</param>
        public BaseController(HttpRequest request = null)
        {
            _Request = request != null ? request : Request;
        }

        /// <summary>
        /// 设置请求对象
        /// </summary>
        /// <param name="request">请求对象</param>
        protected void SetRequest(HttpRequest request)
        {
            if (request != null)
                _Request = request;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public UserInfo CurrentUser
        {
            get { return UserInfo.GetCurretnUser(GetHttpContext(_Request)); }
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns></returns>
        protected UserInfo GetCurrentUser(HttpRequest request)
        {
            return UserInfo.GetCurretnUser(GetHttpContext(request));
        }

        /// <summary>
        /// 当前用户扩展信息集合
        /// </summary>
        public List<EmpExtendInfo> CurrEmpExtendInfos
        {
            get { return UserInfo.GetCurrEmpExtendInfo(CurrentUser); }
        }

        /// <summary>
        /// 当前用户扩展信息
        /// </summary>
        public EmpExtendInfo CurrEmpExtendInfo
        {
            get { return CurrEmpExtendInfos.FirstOrDefault(); }
        }

        /// <summary>
        /// 当前httpContext
        /// </summary>
        public HttpContext CurrHttpContext
        {
            get { return Request.HttpContext; }
        }

        /// <summary>
        /// 获取httpContext对象
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpContext GetHttpContext(HttpRequest request)
        {
            return ApplicationObject.GetHttpContext(request);
        }
    }
}