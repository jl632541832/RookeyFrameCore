using System.Web;
using Rookey.Frame.Operate.Base;
using Rookey.Frame.Base.Set;
using System.Threading.Tasks;
using System;

namespace Rookey.Frame.Controllers.AutoHandle
{
    /// <summary>
    /// 系统应用程序处理类
    /// </summary>
    public static class SysApplicationHandle
    {
        /// <summary>
        /// 应用程序启动
        /// </summary>
        public static void Application_Start()
        {
            try
            {
                //异步处理异常处理，阻止程序崩溃
                TaskScheduler.UnobservedTaskException += (sender, args) =>
                {
                    foreach (var ex in args.Exception.InnerExceptions)
                    {
                        LogOperate.AddExceptionLog(ex, string.Empty);
                    }
                    args.SetObserved();
                };
            }
            catch { }
            try
            {
                //向各数据库注册存储过程
                SystemOperate.RegStoredProcedure();
                //在当前数据库中自动注册外部链接数据库服务器
                SystemOperate.RegCrossDbServer();
            }
            catch { }
            try
            {
                //加载所有启用缓存的模块数据
                if (GlobalSet.IsStartLoadCache)
                {
                    SystemOperate.LoadAllModuleCache();
                }
            }
            catch { }
            //调用自定义应用程序启动方法
            try
            {
                InitFactory factory = InitFactory.GetInstance();
                if (factory != null)
                {
                    factory.App_Start();
                }
            }
            catch { }
            //string msg = ToolOperate.CreateTempModelDLL();
        }
    }
}
