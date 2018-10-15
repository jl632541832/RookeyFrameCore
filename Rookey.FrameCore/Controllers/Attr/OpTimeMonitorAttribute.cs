/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc.Filters;
using Rookey.Frame.Base;
using Rookey.Frame.Common;
using Rookey.Frame.Model.Monitor;
using Rookey.Frame.Model.Sys;
using Rookey.Frame.Operate.Base;
using Rookey.Frame.Operate.Base.OperateHandle;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Rookey.Frame.Controllers.Attr
{
    /// <summary>
    /// 操作时间监控属性
    /// </summary>
    public class OpTimeMonitorAttribute : ActionFilterAttribute
    {
        private DateTime startTime = DateTime.Now;
        private Monitor_OpExecuteTime opExecuteTime = new Monitor_OpExecuteTime();

        /// <summary>
        /// 操作执行前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Sys_Module module = SystemOperate.GetModuleByRequest(filterContext.HttpContext.Request);
                if (module == null)
                {
                    string moduleName = filterContext.HttpContext.Request.Query["moduleName"].ObjToStr();
                    if (string.IsNullOrEmpty(moduleName))
                    {
                        moduleName = filterContext.ActionArguments.ContainsKey("moduleName") ? filterContext.ActionArguments["moduleName"].ObjToStr() : string.Empty;
                        if (string.IsNullOrEmpty(moduleName))
                        {
                            Guid moduleId = filterContext.ActionArguments.ContainsKey("moduleId") ? filterContext.ActionArguments["moduleId"].ObjToGuid() : Guid.Empty;
                            opExecuteTime.ModuleName = moduleId != Guid.Empty ? SystemOperate.GetModuleNameById(moduleId) : string.Empty;
                        }
                        else
                        {
                            opExecuteTime.ModuleName = HttpUtility.UrlDecode(moduleName);
                        }
                    }
                    else
                    {
                        opExecuteTime.ModuleName = HttpUtility.UrlDecode(moduleName);
                    }
                }
                else
                {
                    opExecuteTime.ModuleName = module.Name;
                }
                string controllerName = filterContext.RouteData.Values["controller"].ToString();
                string actionName = filterContext.RouteData.Values["action"].ToString();
                opExecuteTime.ControllerName = controllerName;
                opExecuteTime.ActionName = actionName;
                UserInfo currUser = UserInfo.GetCurretnUser(ApplicationObject.GetHttpContext(filterContext.HttpContext.Request));
                opExecuteTime.OpUserName = currUser.UserName;
                opExecuteTime.ClientIp = WebHelper.GetClientIP(filterContext.HttpContext.Request);
                startTime = DateTime.Now;
            }
            catch { }
        }

        /// <summary>
        /// 操作执行后
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //异步处理
            Task.Factory.StartNew(() =>
            {
                try
                {
                    base.OnResultExecuted(filterContext);
                    opExecuteTime.ExecuteMiniSeconds = (DateTime.Now - startTime).TotalMilliseconds;
                    opExecuteTime.Id = Guid.NewGuid();
                    if (opExecuteTime.ModuleName != "操作时间监控" && opExecuteTime.ClientIp != "::1")
                    {
                        string errMsg = string.Empty;
                        CommonOperate.OperateRecord<Monitor_OpExecuteTime>(opExecuteTime, ModelRecordOperateType.Add, out errMsg, null, false);
                    }
                }
                catch { }
            });
        }
    }
}
