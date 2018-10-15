using Microsoft.AspNetCore.Http;
using Rookey.Frame.Base;
using Rookey.Frame.Common;
using Rookey.Frame.EntityBase;
using Rookey.Frame.EntityBase.Attr;
using Rookey.Frame.Model.Sys;
using Rookey.Frame.Operate.Base.EnumDef;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;

namespace Rookey.Frame.Operate.Base.OperateHandle.Implement
{
    /// <summary>
    /// 模块操作处理
    /// </summary>
    class Sys_ModuleOperateHandle : IModelOperateHandle<Sys_Module>, IGridOperateHandle<Sys_Module>
    {
        #region 模块操作接口
        /// <summary>
        /// 模块操作完成后
        /// </summary>
        /// <param name="operateType"></param>
        /// <param name="t"></param>
        /// <param name="result"></param>
        /// <param name="currUser"></param>
        /// <param name="otherParams"></param>
        public void OperateCompeletedHandle(ModelRecordOperateType operateType, Sys_Module t, bool result, UserInfo currUser, object[] otherParams = null)
        {
            if (operateType == ModelRecordOperateType.Del && result)
            {
                if (t.IsCustomerModule)
                {
                    //自定义模块删除后要删除对应的字段、表单、表单字段、列表、列表字段、列表按钮、字典绑定等信息
                    SystemOperate.DeleteModuleReferences(t);
                }
            }
        }

        /// <summary>
        /// 模块操作前处理
        /// </summary>
        /// <param name="operateType"></param>
        /// <param name="t"></param>
        /// <param name="errMsg"></param>
        /// <param name="otherParams"></param>
        /// <returns></returns>
        public bool BeforeOperateVerifyOrHandle(ModelRecordOperateType operateType, Sys_Module t, out string errMsg, object[] otherParams = null)
        {
            errMsg = string.Empty;
            if (operateType == ModelRecordOperateType.Del)
            {
                //非自定义模块不允许删除
                if (!t.IsCustomerModule)
                {
                    errMsg = string.Format("【{0}】为系统模块，不允许删除！", t.Name);
                    return false;
                }
                else //自定义模块如果有数据则不能删除
                {
                    long count = CommonOperate.Count(out errMsg, t.Id); //模块中记录数
                    if (count > 0)
                    {
                        errMsg = string.Format("模块【{0}】中存在【{0}】条记录，请先清空模块数据后再删除！", t.Name, count);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 模块集合操作完成后
        /// </summary>
        /// <param name="operateType"></param>
        /// <param name="ts"></param>
        /// <param name="result"></param>
        /// <param name="currUser"></param>
        /// <param name="otherParams"></param>
        public void OperateCompeletedHandles(ModelRecordOperateType operateType, List<Sys_Module> ts, bool result, UserInfo currUser, object[] otherParams = null)
        {
            if (operateType == ModelRecordOperateType.Del && result)
            {
                List<Sys_Module> tempModules = ts.Where(x => x.IsCustomerModule).ToList();
                if (tempModules.Count > 0)
                {
                    //自定义模块删除后要删除对应的字段、表单、表单字段、列表、列表字段、列表按钮、字典绑定等信息
                    foreach (Sys_Module t in tempModules)
                    {
                        SystemOperate.DeleteModuleReferences(t);
                    }
                }
            }
        }

        /// <summary>
        /// 模块集合操作完成前
        /// </summary>
        /// <param name="operateType"></param>
        /// <param name="ts"></param>
        /// <param name="errMsg"></param>
        /// <param name="otherParams"></param>
        /// <returns></returns>
        public bool BeforeOperateVerifyOrHandles(ModelRecordOperateType operateType, List<Sys_Module> ts, out string errMsg, object[] otherParams = null)
        {
            errMsg = string.Empty;
            if (operateType == ModelRecordOperateType.Del)
            {
                string otherErr = string.Empty;
                foreach (Sys_Module t in ts)
                {
                    if (!t.IsCustomerModule) //系统模块
                    {
                        //非自定义模块不允许删除
                        errMsg += errMsg == string.Empty ? string.Format("模块【{0}】", t.Name) : string.Format(",【{0}】", t.Name);
                    }
                    else //自定义模块，自定义模块如果有数据则不能删除
                    {
                        long count = CommonOperate.Count(out errMsg, t.Id);
                        if (count > 0)
                        {
                            otherErr += otherErr == string.Empty ? string.Format("模块【{0}】有记录【{1}】条", t.Name, count) : string.Format(",【{0}】有记录【{1}】条", t.Name, count);
                        }
                    }
                }
                if (errMsg != string.Empty)
                {
                    errMsg += "为系统模块，不允许删除！";
                }
                if (otherErr != string.Empty)
                {
                    otherErr += "，请清空各自定义模块的数据后再删除！";
                }
                errMsg = errMsg + otherErr;
                if (!string.IsNullOrEmpty(errMsg))
                    return false;
            }
            return true;
        }
        #endregion
        #region 网格接口
        /// <summary>
        /// 网格参数设置
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="gridParams"></param>
        /// <param name="request"></param>
        public void GridParamsSet(EnumDef.DataGridType gridType, TempModel.GridParams gridParams, HttpRequest request = null)
        {
        }

        /// <summary>
        /// 网格数据加载参数设置
        /// </summary>
        /// <param name="module"></param>
        /// <param name="gridDataParams"></param>
        /// <param name="request"></param>
        public void GridLoadDataParamsSet(Sys_Module module, TempModel.GridDataParmas gridDataParams, HttpRequest request = null)
        {
        }

        /// <summary>
        /// 网格数据处理
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="otherParams">其他参数</param>
        /// <param name="currUser">当前用户</param>
        public void PageGridDataHandle(List<Sys_Module> data, object[] otherParams = null, UserInfo currUser = null)
        {
            if (data != null && data.Count > 0)
            {
                data.ForEach(x =>
                {
                    if (string.IsNullOrEmpty(x.Display))
                        x.Display = x.Name;
                });
            }
        }

        /// <summary>
        /// 网格条件
        /// </summary>
        /// <returns></returns>
        public Expression<Func<Sys_Module, bool>> GetGridFilterCondition(out string where, EnumDef.DataGridType gridType, Dictionary<string, string> condition = null, string initModule = null, string initField = null, Dictionary<string, string> otherParams = null, UserInfo currUser = null)
        {
            where = string.Empty;
            return null;
        }

        /// <summary>
        /// 网格按钮操作验证
        /// </summary>
        /// <param name="buttonText">按钮显示名称</param>
        /// <param name="ids">操作记录id集合</param>
        /// <param name="otherParams">其他参数</param>
        /// <param name="currUser">当前用户</param>
        /// <returns></returns>
        public string GridButtonOperateVerify(string buttonText, List<Guid> ids, object[] otherParams = null, UserInfo currUser = null)
        {
            return string.Empty;
        }
        #endregion
    }
}
