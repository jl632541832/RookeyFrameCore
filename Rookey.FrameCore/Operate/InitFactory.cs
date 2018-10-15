using Rookey.Frame.Base;
using Rookey.Frame.Bridge;
using System;
using System.Linq;

namespace Rookey.Frame.Operate.Base
{
    /// <summary>
    /// 初始化工厂类
    /// </summary>
    public abstract class InitFactory
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static InitFactory GetInstance()
        {
            InitFactory factory = null;
            Type type = BridgeObject.GetCustomerOperateHandleTypes().Where(x => x.BaseType == typeof(InitFactory)).FirstOrDefault();
            if (type != null)
            {
                object obj = Activator.CreateInstance(type);
                return obj as InitFactory;
            }
            return factory;
        }

        /// <summary>
        /// 应用程序启动事件
        /// </summary>
        public abstract void App_Start();

        /// <summary>
        /// 自定义初始化，包括菜单、模块、字段、字典等数据初始化
        /// </summary>
        public abstract void CustomerInit();

        /// <summary>
        /// 获取自定义桌面URL
        /// </summary>
        /// <param name="currUser">当前用户</param>
        /// <returns></returns>
        public abstract string GetDesktopPageUrl(UserInfo currUser);

        /// <summary>
        /// 添加自定义后台任务
        /// </summary>
        public abstract void AddBackgroundTask();
    }
}
