namespace Rookey.Frame.Common.Model
{
    /// <summary>
    /// 系统连接字符串类
    /// </summary>
    public class ConnectionStrings
    {
        public string DbReadConnString { get; }

        public string DbWriteConnString { get; }
    }

    /// <summary>
    /// 系统设置类
    /// </summary>
    public class AppSetting
    {
        public string NeedRepairTable { get; }
        public string RepairTables { get; }
        public string NeedInit { get; }
        public string DbType { get; }
        public string ViewConfig { get; }
        public string EmailServer { get; }
        public string SysEmail { get; }
        public string SysEmailPwd { get; }
        public string SysEmailDes { get; }
        public string TestEmail { get; }
        public string WebServer { get; }
        public string WebHost { get; }
        public string WebIndex { get; }
        public string DefaultController { get; }
        public string DefaultAction { get; }
        public string QuartzJob { get; }
        public string QuartzServer { get; }
        public string IsSecondCache { get; }
        public string CanReceiveCacheHosts { get; }
        public string CanChangeOps { get; }
        public string UIMarkStyle { get; }
        public string IsEnabledPageCache { get; set; }
    }
}
