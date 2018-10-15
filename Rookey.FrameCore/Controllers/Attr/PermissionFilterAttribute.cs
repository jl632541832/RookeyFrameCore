/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Rookey.Frame.Common;
using System;

namespace Rookey.Frame.Controllers.Attr
{
    /// <summary>
    /// 权限拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 权限拦截
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            //接下来进行权限拦截与验证
            if (!this.AuthorizeCore(filterContext))//根据验证判断进行处理
            {
                string loginUrl = "/user/login.html";
                string returnUrl = filterContext.HttpContext.Request.Query["returnUrl"].ObjToStr();
                if (!string.IsNullOrEmpty(returnUrl))
                    loginUrl += string.Format("?returnUrl={0}", returnUrl);
                string loginContent = string.Format("<script>top.location.href='{0}';</script>", loginUrl);
                //是否ajax请求
                bool isAjax = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (isAjax)
                {
                    //未登录验证
                    if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        //弹出登录页面框
                        filterContext.Result = new ContentResult() { Content = loginContent, ContentType = "text/html" };
                        return;
                    }
                    return;
                }
                //跳转到登录页面
                filterContext.Result = new ContentResult() { Content = loginContent, ContentType = "text/html" };
                return;
            }
        }

        /// <summary>
        /// [Anonymous标记]验证是否匿名访问
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        public bool CheckAnonymous(ActionExecutingContext filterContext)
        {
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                //验证是否是匿名访问的Action
                object[] attrsAnonymous = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(AnonymousAttribute), true);
                //是否是Anonymous
                return attrsAnonymous.Length >= 1;
            }
            return false;
        }

        /// <summary>
        /// [LoginAllowView标记]验证是否登录就可以访问(如果已经登陆,那么不对于标识了LoginAllowView的方法就不需要验证了)
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        public bool CheckLoginAllowView(ActionExecutingContext filterContext)
        {
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                //在这里允许一种情况,如果已经登陆,那么不对于标识了LoginAllowView的方法就不需要验证了
                object[] attrs = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(LoginAllowViewAttribute), true);
                //是否是LoginAllowView
                return attrs.Length >= 1;
            }
            return false;
        }

        /// <summary>
        /// //权限判断业务逻辑
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        protected virtual bool AuthorizeCore(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext == null)
            {
                return false;
            }
            //验证当前Action是否是匿名访问Action
            if (CheckAnonymous(filterContext))
                return true;
            //未登录验证
            AuthenticateResult result = filterContext.HttpContext.AuthenticateAsync().Result;
            if (!result.Succeeded)
                return false;
            //验证当前Action是否是登录就可以访问的Action
            if (CheckLoginAllowView(filterContext))
                return true;
            //下面开始用户权限验证
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();

            return true;
        }
    }
}