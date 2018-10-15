/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.Extensions.DependencyInjection;
using Rookey.Frame.Common.Model;
using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Rookey.Frame.Common
{
    /// <summary>
    /// WebConfig操作帮助类
    /// </summary>
    public static class WebConfigHelper
    {
        /// <summary>
        /// 存储AppSettingValue
        /// </summary>
        private static ConcurrentDictionary<string, string> appSettingCaches = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 获取配置文件AppSetting值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingValue(string key)
        {
            try
            {
                string value = string.Empty;
                if (appSettingCaches.ContainsKey(key))
                {
                    try
                    {
                        appSettingCaches.TryGetValue(key, out value);
                        if (value != null)
                            return value;
                    }
                    catch { }
                }
                value = DI.Configuration.GetSection("AppSetting:" + key).Value;
                if (value != null)
                {
                    try
                    {
                        appSettingCaches.TryAdd(key, value);
                    }
                    catch { }
                }
                return value;
            }
            catch { }
            return string.Empty;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            try
            {
                PropertyInfo p = typeof(ConnectionStrings).GetProperty(name);
                if (p != null)
                {
                    string connStringStr = DI.Configuration.GetSection("ConnectionStrings:" + name).Value;
                    return connStringStr;
                }
            }
            catch { }
            return string.Empty;
        }

        #region 网站信息

        /// <summary>
        /// 获取当前网站系统名称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrWebName()
        {
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            string basePath = WebHelper.MapPath("/") + pathFlag;
            string webConfigPath = string.Format("{0}Config{1}webConfig.xml", basePath, pathFlag);
            if (!System.IO.File.Exists(webConfigPath)) //文件不存在
                return string.Empty;
            string name = XmlHelper.Read(webConfigPath, "/web/name");
            return name;
        }

        /// <summary>
        /// 获取当前网站系统LOGO
        /// </summary>
        /// <returns></returns>
        public static string GetCurrWebLogo()
        {
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            string basePath = WebHelper.MapPath("/") + pathFlag;
            string webConfigPath = string.Format("{0}Config{1}webConfig.xml", basePath, pathFlag);
            if (!System.IO.File.Exists(webConfigPath)) //文件不存在
                return string.Empty;
            string name = XmlHelper.Read(webConfigPath, "/web/logo");
            return name;
        }

        /// <summary>
        /// 获取网站logo右边名称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrLogoName()
        {
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            string basePath = WebHelper.MapPath("/") + pathFlag;
            string webConfigPath = string.Format("{0}Config{1}webConfig.xml", basePath, pathFlag);
            if (!System.IO.File.Exists(webConfigPath)) //文件不存在
                return string.Empty;
            string name = XmlHelper.Read(webConfigPath, "/web/logoName");
            return name;
        }

        /// <summary>
        /// 获取当前网站系统Copyright
        /// </summary>
        /// <returns></returns>
        public static string GetCurrWebCopyright()
        {
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            string basePath = WebHelper.MapPath("/") + pathFlag;
            string webConfigPath = string.Format("{0}Config{1}webConfig.xml", basePath, pathFlag);
            if (!System.IO.File.Exists(webConfigPath)) //文件不存在
                return string.Empty;
            string name = XmlHelper.Read(webConfigPath, "/web/copyright");
            return name;
        }

        /// <summary>
        /// 设置网站信息
        /// </summary>
        /// <param name="name">系统名称</param>
        /// <param name="logo">系统LOGO</param>
        /// <param name="copyright">版权信息</param>
        /// <returns>返回异常信息</returns>
        public static string SetCurrWebInfo(string name, string logo, string copyright)
        {
            try
            {
                string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                string basePath = WebHelper.MapPath("/") + pathFlag;
                string webConfigPath = string.Format("{0}Config{1}webConfig.xml", basePath, pathFlag);
                if (!System.IO.File.Exists(webConfigPath)) //文件不存在
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                    sb.Append("<web>");
                    sb.AppendFormat("<name>{0}</name>", name);
                    sb.AppendFormat("<logo>{0}</logo>", logo);
                    sb.AppendFormat("<copyright>{0}</copyright>", copyright);
                    sb.Append("</web>");
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(webConfigPath, false, Encoding.UTF8);
                    sw.Write(sb.ToString());
                    sw.Close();
                    return string.Empty;
                }
                XmlHelper.Update(webConfigPath, "/web/name", name);
                XmlHelper.Update(webConfigPath, "/web/logo", logo);
                XmlHelper.Update(webConfigPath, "/web/copyright", copyright);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}
