using Microsoft.AspNetCore.Mvc.Razor;
using Rookey.Frame.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rookey.Frame.Controllers.AppConfig
{
    /// <summary>
    /// 自定义视图引擎类
    /// </summary>
    public sealed class MyViewEngine : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            List<string> viewFormats = new List<string>()
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Page/{0}.cshtml", //自定义View规则 
                "~/Views/Page/Common/{0}.cshtml", //自定义View规则
                "~/Views/Page/System/{0}.cshtml", //自定义View规则
                "~/Views/Page/Permission/{0}.cshtml", //自定义View规则
                "~/Views/Page/Desktop/{0}.cshtml", //自定义View规则
                "~/Views/Page/Email/{0}.cshtml" //自定义View规则
            };
            string otherViewConfigs = WebConfigHelper.GetAppSettingValue("ViewConfig");
            if (!string.IsNullOrEmpty(otherViewConfigs)) //其他视图配置
            {
                List<string> token = otherViewConfigs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                viewFormats.AddRange(token);
            }
            return viewFormats;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
}