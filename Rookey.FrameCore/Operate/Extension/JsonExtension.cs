﻿/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rookey.Frame.Operate.Base.TempModel;
using System.Collections;
using System.Collections.Generic;

namespace Rookey.Frame.Operate.Base.Extension
{
    /// <summary>
    /// 序列化扩展类
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 序列化为MVC支持的JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static ContentResult ToJson<T>(this List<T> list)
        {
            var json = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented, new JavaScriptDateTimeConverter());

            return new ContentResult()
            {
                Content = json,
                ContentType = "application/json"
            };
        }

        /// <summary>
        /// 序列化为MVC支持的JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ContentResult ToJson<T>(this T model)
        {
            var json = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented, new JavaScriptDateTimeConverter());

            return new ContentResult()
            {
                Content = json,
                ContentType = "application/json"
            };
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageData">分页数据</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static JsonResult Paged(this IEnumerable pageData, long totalCount)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (pageData == null) pageData = new List<object>();
            dic.Add(PageInfo.pageDataKeyWord, pageData);
            dic.Add(PageInfo.totalRecordKeyWord, totalCount);

            JsonSerializerSettings jsonSetings = new JsonSerializerSettings();
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            jsonSetings.Converters = new List<JsonConverter>() { timeConverter };
            jsonSetings.Formatting = Formatting.Indented;
            
            return new JsonResult(dic, jsonSetings);
        }
    }
}
