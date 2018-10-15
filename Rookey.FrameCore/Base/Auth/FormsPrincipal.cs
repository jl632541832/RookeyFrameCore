/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Rookey.Frame.Common;
using System;
using System.Security.Claims;

namespace Rookey.Frame.Base
{
    /// <summary>
    /// 表单认证
    /// </summary>
    public sealed class FormsPrincipal
    {
        public const string COOKIE_NAME = "UserAuth";

        /// <summary>
        /// 执行用户登录操作
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="userData">与登录名相关的用户信息</param>
        /// <param name="expiration">登录Cookie的过期时间，单位：分钟。</param>
        /// <param name="currContext">当前context</param>
        public static void Login(string loginName, UserInfo userData, int expiration, HttpContext currContext)
        {
            if (string.IsNullOrEmpty(loginName))
                return;
            if (userData == null || currContext == null)
                return;
            //登录认证处理
            //userData.ExtendUserObject = null; 数据长度太长cookie装不下时先把扩展对象置空
            string data = JsonHelper.Serialize(userData); //序列化用户基本信息

            var claimsIdentity = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, loginName), new Claim(ClaimTypes.UserData, data) }, "Basic");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            currContext.SignInAsync(COOKIE_NAME, claimsPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(12),
                IsPersistent = false,
                AllowRefresh = false
            });
        }

        /// <summary>
        /// 安全退出系统
        /// </summary>
        /// <param name="currContext">当前context</param>
        public static void Logout(HttpContext currContext)
        {
            if (currContext == null)
                return;
            currContext.SignOutAsync(COOKIE_NAME);
        }
    }
}
