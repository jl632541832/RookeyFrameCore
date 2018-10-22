using Rookey.Frame.Common;
using Rookey.Frame.Common.Model;
using Rookey.Frame.Common.PubDefine;
using Rookey.Frame.Model.Other;
using Rookey.Frame.Operate.Base.OperateHandle;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rookey.Frame.Operate.Base
{
    /// <summary>
    /// 其他操作类
    /// </summary>
    public static class OtherOperate
    {
        #region 分布式锁
        private static readonly object tempObjDistriLock = new object();
        /// <summary>
        /// 取分布式锁（基于DB方式）
        /// </summary>
        /// <param name="moduleFlag">模块标识，模块表名/类名</param>
        /// <param name="method_Flag">方法名标识</param>
        /// <param name="expirtime">自定义过期时间（秒）</param>
        /// <param name="des">锁描述</param>
        /// <returns></returns>
        public static string DistributeDbLock(string moduleFlag, string method_Flag, double? expirtime = null, string des = null)
        {
            try
            {
                if (WebConfigHelper.GetAppSettingValue("EnabledDistributeLock") != "true") //未启用分布式锁
                    return string.Empty;
                string hostname = System.Net.Dns.GetHostName(); //当前服务器
                string processId = ApplicationObject.GetCurrentProcessId();//当前进程
                string threadId = ApplicationObject.GetCurrentThreadId();//当前线程
                lock (tempObjDistriLock)
                {
                    string errMsg = string.Empty;
                    int timeout = 30; //30秒超时
                    DateTime initTime = DateTime.Now;
                    DatabaseType dbType = DatabaseType.MsSqlServer;
                    string connStr = ModelConfigHelper.GetModelConnStr(typeof(Other_DistributedLock), out dbType, false);
                    while ((DateTime.Now - initTime).TotalSeconds <= timeout)
                    {
                        double updateTimesamp = Globals.GetTimestamp(DateTime.Now);//当前时间戳
                        double invalidTimesamp = expirtime.HasValue && expirtime.Value > 0 ? updateTimesamp + expirtime.Value : updateTimesamp + 20;//过期时间戳
                        Other_DistributedLock methodLock = CommonOperate.GetEntity<Other_DistributedLock>(x => x.ModuleFlag == moduleFlag && x.Method_Flag == method_Flag && x.Invalid_Timesamp > updateTimesamp, null, out errMsg);
                        //锁存在，继续循环再取
                        if (methodLock != null)
                        {
                            Thread.Sleep(10);
                            continue;
                        }
                        //锁不存在，取得锁成功，插入锁标识
                        methodLock = new Other_DistributedLock()
                        {
                            ModuleFlag = moduleFlag,
                            Method_Flag = method_Flag,
                            Update_Timesamp = updateTimesamp,
                            Invalid_Timesamp = invalidTimesamp,
                            Maching = hostname,
                            ProcessId = processId,
                            ThreadId = threadId,
                            Des = des
                        };
                        TransactionTask tranAction = (conn) =>
                        {
                            CommonOperate.DeleteRecordsByExpression<Other_DistributedLock>(x => x.ModuleFlag == moduleFlag && x.Method_Flag == method_Flag, out errMsg, false, connStr, dbType, conn);
                            if (!string.IsNullOrEmpty(errMsg))
                                throw new Exception(errMsg);
                            CommonOperate.OperateRecord<Other_DistributedLock>(methodLock, ModelRecordOperateType.Add, out errMsg, null, false, false, connStr, dbType, conn);
                            if (!string.IsNullOrEmpty(errMsg))
                                throw new Exception(errMsg);
                        };
                        CommonOperate.TransactionHandle(tranAction, out errMsg, connStr, dbType);
                        //取锁成功
                        if (string.IsNullOrEmpty(errMsg))
                            return string.Empty;
                        else
                            WritLockLog(moduleFlag, method_Flag, errMsg);
                        //取锁失败，继续循环取
                        Thread.Sleep(10);
                    }
                    return "获取分布式锁超时"; //取锁失败
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 释放分布式锁（基于DB方式）
        /// </summary>
        /// <param name="moduleFlag">模块标识，模块表名/类名</param>
        /// <param name="method_Flag">方法名标识</param>
        /// <returns></returns>
        public static string ReleaseDistDbLock(string moduleFlag, string method_Flag)
        {
            if (WebConfigHelper.GetAppSettingValue("EnabledDistributeLock") != "true") //未启用分布式锁
                return string.Empty;
            lock (tempObjDistriLock)
            {
                string errMsg = string.Empty;
                CommonOperate.DeleteRecordsByExpression<Other_DistributedLock>(x => x.ModuleFlag == moduleFlag && x.Method_Flag == method_Flag, out errMsg);
                return string.Empty;
            }
        }

        /// <summary>
        /// 写锁日志
        /// </summary>
        /// <param name="moduleFlag">模块标识，模块表名/类名</param>
        /// <param name="method_Flag">方法名标识</param>
        /// <param name="errMsg">失败信息</param>
        private static void WritLockLog(string moduleFlag, string method_Flag, string errMsg)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    string dir = AppDomain.CurrentDomain.BaseDirectory + "LockErr";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    string pathFlag = Path.DirectorySeparatorChar.ToString();
                    string path = string.Format("{0}{2}{1}.txt", dir, DateTime.Now.ToString("yyyy-MM-dd"), pathFlag);
                    StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);
                    sw.WriteLine(string.Format("Date：{0}，ModuleFlag：{1}，Method_Flag：{2}，ErrMsg：{3} \n ", DateTime.Now.ToString(), moduleFlag, method_Flag, errMsg));
                    sw.Close();
                });
            }
            catch { }
        }
        #endregion
    }
}
