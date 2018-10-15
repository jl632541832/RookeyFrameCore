using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Rookey.Frame.Common
{
    /// <summary>
    /// Web辅助处理类
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// 应用程序目录的绝对路径
        /// </summary>
        private static string _rootPath = DI.ServiceProvider.GetRequiredService<IHostingEnvironment>().ContentRootPath;

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns></returns>
        public static string GetClientIP(HttpRequest request)
        {
            if (request == null) return string.Empty;
            string clientIp = string.Empty;
            if (request.Headers["HTTP_VIA"].FirstOrDefault() != null) //使用代理
            {
                clientIp = request.Headers["HTTP_X_FORWARDED_FOR"].FirstOrDefault(); // 返回真实的客户端IP 
            }
            else// 没有使用代理时获取客户端IP 
            {
                clientIp = request.Headers["REMOTE_ADDR"].FirstOrDefault(); //当不能获取客户端IP时,将获取客户端代理IP. 
            }
            return clientIp;
        }

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <param name="context">上下文请求对象</param>
        /// <returns></returns>
        public static string GetClientIP(HttpContext context)
        {
            if (context == null) return string.Empty;
            string clientIp = GetClientIP(context.Request);
            return clientIp;
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="configName">配置文件名，带文件扩展名</param>
        /// <returns></returns>
        public static string GetConfigFilePath(string configName)
        {
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            string basePath = WebHelper.MapPath("/") + pathFlag;
            string xmlPath = basePath + string.Format("Config{0}{1}", pathFlag, configName);
            if (!System.IO.File.Exists(xmlPath)) //文件不存在
                return string.Empty;
            return xmlPath;
        }

        /// <summary>
        /// 获取JS的修改时间
        /// </summary>
        /// <param name="jsPath">JS的URL路径</param>
        /// <returns></returns>
        public static string GetJsModifyTimeStr(string jsPath)
        {
            if (string.IsNullOrEmpty(jsPath))
                return string.Empty;
            string tempPath = jsPath;
            try
            {
                if (tempPath.StartsWith("/"))
                    tempPath = tempPath.Substring(1, tempPath.Length - 1);
            }
            catch
            {
                return string.Empty;
            }
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            string filePath = Globals.GetWebDir();
            filePath += jsPath.Replace("/", pathFlag);
            if (!System.IO.File.Exists(filePath)) //js不存在
                return string.Empty;
            try
            {
                FileInfo fi = new FileInfo(filePath);
                string r = fi.LastWriteTime.ToString("yyMMddHHmmss");
                return r;
            }
            catch { }
            return string.Empty;
        }

        // <summary>
        /// 获取文件绝对路径
        　　/// </summary>
        　　/// <param name="path">文件路径</param>
        　　/// <returns></returns>
        public static string MapPath(string path)
        {
            return IsAbsolute(path) ? path : Path.Combine(_rootPath, path.TrimStart('~', '/').Replace("/", Path.DirectorySeparatorChar.ToString()));
        }

        /// <summary>
        /// 是否是绝对路径
        /// windows下判断 路径是否包含 ":"
        /// Mac OS、Linux下判断 路径是否包含 "\"
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsAbsolute(string path)
        {
            try
            {
                return Path.VolumeSeparatorChar == ':' ? path.IndexOf(Path.VolumeSeparatorChar) > 0 : path.IndexOf('\\') > 0;
            }
            catch { }
            return false;
        }

        /// <summary>
        /// url参数查询扩展
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object QueryEx(this HttpRequest request, string key)
        {
            if (request == null)
                return null;
            object obj = null;
            try
            {
                if (request.Query.ContainsKey(key))
                {
                    obj = request.Query[key];
                }
                else if (request.Form.ContainsKey(key))
                {
                    obj = request.Form[key];
                }
            }
            catch
            {
                obj = null;
            }
            return obj;
        }

        /// <summary>
        /// url参数扩展DIC
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string,object> QueryExDic(this HttpRequest request)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (request == null)
                return dic;
            try
            {
                dic = request.Query.ToDictionary();
                foreach(var obj in request.Form)
                {
                    if (!dic.ContainsKey(obj.Key))
                        dic.Add(obj.Key, obj.Value);
                }
            }
            catch { }
            return dic;
        }
    }
}
