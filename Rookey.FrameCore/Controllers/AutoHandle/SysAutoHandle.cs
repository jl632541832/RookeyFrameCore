/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Rookey.Frame.AutoProcess;
using Rookey.Frame.Common;
using Rookey.Frame.Model.Bpm;
using Rookey.Frame.Model.Other;
using Rookey.Frame.Model.EnumSpace;
using Rookey.Frame.Operate.Base;
using System;
using System.Collections.Generic;

namespace Rookey.Frame.Controllers.AutoHandle
{
    /// <summary>
    /// 系统自动任务
    /// </summary>
    public class SysAutoHandle
    {
        /// <summary>
        /// 添加后台系统任务
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public static void SysBackgroundTaskAdd(object obj, EventArgs e)
        {
            if (WebConfigHelper.GetAppSettingValue("IsRunBgTask") == "true")
            {
                try
                {
                    #region 重建索引
                    //重建索引任务
                    BackgroundTask reBuildIndexTask = new BackgroundTask((args) =>
                    {
                        if (DateTime.Now.Hour == 4 && DateTime.Now.Minute == 0)
                            SystemOperate.RebuildAllTableIndex();
                        return true;
                    }, null, false, 45, false);
                    AutoProcessTask.AddTask(reBuildIndexTask);
                    #endregion
                    #region 迁移历史审批数据
                    //审批完成后的数据迁移到待办历史数据表中，针对审批是迁移失败的处理
                    BackgroundTask todoStatusHandleTask = new BackgroundTask((args) =>
                    {
                        if ((DateTime.Now.Hour == 3 && DateTime.Now.Minute == 0) ||
                            (DateTime.Now.Hour == 12 && DateTime.Now.Minute == 40))
                        {
                            //审批完成数据迁移异常处理
                            try
                            {
                                string errMsg = string.Empty;
                                int refuseStatus = (int)WorkFlowStatusEnum.Refused;
                                int overStatus = (int)WorkFlowStatusEnum.Over;
                                int obsoStatus = (int)WorkFlowStatusEnum.Obsoleted;
                                List<Bpm_WorkFlowInstance> flowInsts = CommonOperate.GetEntities<Bpm_WorkFlowInstance>(out errMsg, x => x.Status == refuseStatus || x.Status == overStatus || x.Status == obsoStatus, null, false);
                                if (flowInsts != null && flowInsts.Count > 0)
                                {
                                    foreach (Bpm_WorkFlowInstance flowInst in flowInsts)
                                    {
                                        BpmOperate.TransferWorkToDoHistory(flowInst, null);
                                    }
                                }
                            }
                            catch { }
                        }
                        return true;
                    }, null, false, 45, false);
                    AutoProcessTask.AddTask(todoStatusHandleTask);
                    #endregion
                    #region 附件在线预览生成
                    BackgroundTask attachOnlineViewHandleTask = new BackgroundTask((args) =>
                    {
                        if (DateTime.Now.Hour == 4 && DateTime.Now.Minute == 0)
                        {
                            SystemOperate.ExecCreateSwfTask();
                        }
                        return true;
                    }, null, false, 45, false);
                    AutoProcessTask.AddTask(attachOnlineViewHandleTask);
                    #endregion
                    #region 基于DB的失效分布式锁释放
                    BackgroundTask dbLockReleaseHandleTask = new BackgroundTask((args) =>
                    {
                        if (WebConfigHelper.GetAppSettingValue("EnabledDistributeLock") == "true") //启用分布式锁
                        {
                            string errMsg = string.Empty;
                            double nowTimesamp = Globals.GetTimestamp(DateTime.Now);//当前时间戳
                            CommonOperate.DeleteRecordsByExpression<Other_DistributedLock>(x => x.Invalid_Timesamp < nowTimesamp, out errMsg);
                        }
                        return true;
                    }, null, false, 60, false);
                    AutoProcessTask.AddTask(dbLockReleaseHandleTask);
                    #endregion
                }
                catch { }
            }
            try
            {
                InitFactory factory = InitFactory.GetInstance();
                if (factory != null)
                {
                    factory.AddBackgroundTask();
                }
            }
            catch { }
        }
    }
}
