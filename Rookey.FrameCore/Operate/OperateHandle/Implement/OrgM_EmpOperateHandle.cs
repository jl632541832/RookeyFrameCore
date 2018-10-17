using Microsoft.AspNetCore.Http;
using Rookey.Frame.Base;
using Rookey.Frame.Base.Set;
using Rookey.Frame.Common;
using Rookey.Frame.Model.EnumSpace;
using Rookey.Frame.Model.OrgM;
using Rookey.Frame.Model.Sys;
using Rookey.Frame.Operate.Base.EnumDef;
using Rookey.Frame.Operate.Base.TempModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace Rookey.Frame.Operate.Base.OperateHandle.Implement
{
    /// <summary>
    /// 员工操作处理类
    /// </summary>
    class OrgM_EmpOperateHandle : IModelOperateHandle<OrgM_Emp>, IGridOperateHandle<OrgM_Emp>, IFormOperateHandle<OrgM_Emp>
    {
        #region 实体操作
        /// <summary>
        /// 员工操作完成
        /// </summary>
        /// <param name="operateType">操作类型</param>
        /// <param name="t">员工对象</param>
        /// <param name="result">操作结果</param>
        /// <param name="currUser">当前用户</param>
        /// <param name="otherParams"></param>
        public void OperateCompeletedHandle(ModelRecordOperateType operateType, OrgM_Emp t, bool result, UserInfo currUser, object[] otherParams = null)
        {
            if (result)
            {
                string errMsg = string.Empty;
                string username = OrgMOperate.GetUserNameByEmp(t);
                if (operateType == ModelRecordOperateType.Add)
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        UserOperate.AddUser(out errMsg, username, string.Format("{0}_123456", username), null, t.Name);
                    }
                }
                else if (operateType == ModelRecordOperateType.Edit)
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        UserOperate.UpdateUserAliasName(username, t.Name);
                    }
                }
                else if (operateType == ModelRecordOperateType.Del)
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        UserOperate.DelUser(username); //删除账号
                    }
                    //删除员工同时删除员工岗位
                    CommonOperate.DeleteRecordsByExpression<OrgM_EmpDeptDuty>(x => x.OrgM_EmpId == t.Id, out errMsg, t.IsDeleted);
                }
                if (operateType == ModelRecordOperateType.Add || operateType == ModelRecordOperateType.Edit)
                {
                    //新增编辑时同时设置员工主职岗位
                    if (t.DeptId.HasValue && t.DeptId.Value != Guid.Empty && t.DutyId.HasValue && t.DutyId.Value != Guid.Empty)
                    {
                        OrgM_EmpDeptDuty empPosition = null;
                        if (operateType == ModelRecordOperateType.Edit)
                        {
                            empPosition = CommonOperate.GetEntity<OrgM_EmpDeptDuty>(x => x.OrgM_EmpId == t.Id && x.IsMainDuty == true, null, out errMsg);
                            if (empPosition != null)
                            {
                                empPosition.OrgM_DeptId = t.DeptId.Value;
                                empPosition.OrgM_DutyId = t.DutyId.Value;
                                empPosition.IsValid = true;
                                empPosition.ModifyDate = DateTime.Now;
                                empPosition.ModifyUserId = currUser.UserId;
                                empPosition.ModifyUserName = currUser.EmpName;
                                CommonOperate.OperateRecord<OrgM_EmpDeptDuty>(empPosition, ModelRecordOperateType.Edit, out errMsg, null, false);
                                return;
                            }
                        }
                        empPosition = new OrgM_EmpDeptDuty()
                        {
                            OrgM_DeptId = t.DeptId.Value,
                            OrgM_DutyId = t.DutyId.Value,
                            OrgM_EmpId = t.Id,
                            IsMainDuty = true,
                            IsValid = true,
                            EffectiveDate = DateTime.Now,
                            CreateDate = DateTime.Now,
                            CreateUserId = currUser.UserId,
                            CreateUserName = currUser.EmpName,
                            ModifyDate = DateTime.Now,
                            ModifyUserId = currUser.UserId,
                            ModifyUserName = currUser.EmpName
                        };
                        CommonOperate.OperateRecord<OrgM_EmpDeptDuty>(empPosition, ModelRecordOperateType.Add, out errMsg, null, false);
                    }
                }
            }
        }

        /// <summary>
        /// 员工操作前验证
        /// </summary>
        /// <param name="operateType">操作类型</param>
        /// <param name="t">操作对象</param>
        /// <param name="errMsg">异常信息</param>
        /// <param name="otherParams"></param>
        /// <returns></returns>
        public bool BeforeOperateVerifyOrHandle(ModelRecordOperateType operateType, OrgM_Emp t, out string errMsg, object[] otherParams = null)
        {
            errMsg = string.Empty;
            return true;
        }

        /// <summary>
        /// 批量操作完成后事件
        /// </summary>
        /// <param name="operateType"></param>
        /// <param name="ts"></param>
        /// <param name="result"></param>
        /// <param name="currUser">当前用户</param>
        /// <param name="otherParams"></param>
        public void OperateCompeletedHandles(ModelRecordOperateType operateType, List<OrgM_Emp> ts, bool result, UserInfo currUser, object[] otherParams = null)
        {
            if (ts != null && ts.Count > 0)
            {
                foreach (OrgM_Emp t in ts)
                {
                    OperateCompeletedHandle(operateType, t, result, currUser, otherParams);
                }
            }
        }

        /// <summary>
        /// 批量操作前验证事件
        /// </summary>
        /// <param name="operateType"></param>
        /// <param name="ts"></param>
        /// <param name="errMsg"></param>
        /// <param name="otherParams"></param>
        /// <returns></returns>
        public bool BeforeOperateVerifyOrHandles(ModelRecordOperateType operateType, List<OrgM_Emp> ts, out string errMsg, object[] otherParams = null)
        {
            errMsg = string.Empty;
            return true;
        }
        #endregion
        #region 网格处理
        /// <summary>
        /// 网格参数重写
        /// </summary>
        /// <param name="gridType">网格类型</param>
        /// <param name="gridParams">网格参数</param>
        /// <param name="request">请求对象</param>
        public void GridParamsSet(DataGridType gridType, GridParams gridParams, HttpRequest request = null)
        {
            Sys_GridField enameField = gridParams.GridFields.Where(x => x.Sys_FieldName == "EName").FirstOrDefault();
            int index = gridParams.GridFields.IndexOf(enameField);
            gridParams.GridFields.Insert(index + 1, new Sys_GridField() { Sys_FieldName = "DeptId", Sort = 3, AlignOfEnum = AlignTypeEnum.Left, Width = 0, IsVisible = false });
            gridParams.GridFields.Insert(index + 1, new Sys_GridField() { Sys_FieldName = "DeptName", Display = "部门", Sort = 3, AlignOfEnum = AlignTypeEnum.Left, Width = 120, IsVisible = true });
            gridParams.GridFields.Insert(index + 2, new Sys_GridField() { Sys_FieldName = "DutyId", Sort = 3, AlignOfEnum = AlignTypeEnum.Left, Width = 0, IsVisible = false });
            gridParams.GridFields.Insert(index + 2, new Sys_GridField() { Sys_FieldName = "DutyName", Display = "职务", Sort = 4, AlignOfEnum = AlignTypeEnum.Left, Width = 120, IsVisible = true });
        }
        /// <summary>
        /// 网格数据加载参数重写
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="gridDataParams">数据加载参数</param>
        /// <param name="request">请求对象</param>
        public void GridLoadDataParamsSet(Sys_Module module, GridDataParmas gridDataParams, HttpRequest request = null)
        {
        }
        /// <summary>
        /// 网格数据处理
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="otherParams">其他参数</param>
        /// <param name="currUser">当前用户</param>
        public bool PageGridDataHandle(List<OrgM_Emp> data, object[] otherParams = null, UserInfo currUser = null)
        {
            if (data != null && data.Count > 0)
            {
                foreach (OrgM_Emp t in data)
                {
                    OrgM_EmpDeptDuty empPosition = OrgMOperate.GetEmpMainPosition(t.Id);
                    if (empPosition != null)
                    {
                        if (empPosition.OrgM_DeptId.HasValue && empPosition.OrgM_DeptId.Value != Guid.Empty &&
                            empPosition.OrgM_DutyId.HasValue && empPosition.OrgM_DutyId.Value != Guid.Empty)
                        {
                            OrgM_Dept dept = OrgMOperate.GetDeptById(empPosition.OrgM_DeptId.Value);
                            if (dept != null)
                            {
                                t.DeptId = dept.Id;
                                t.DeptName = string.IsNullOrEmpty(dept.Alias) ? dept.Name : dept.Alias;
                            }
                            OrgM_Duty duty = OrgMOperate.GetDuty(empPosition.OrgM_DutyId.Value);
                            if (duty != null)
                            {
                                t.DutyId = duty.Id;
                                t.DutyName = duty.Name;
                            }
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 网格条件过滤
        /// </summary>
        /// <param name="where">where</param>
        /// <param name="gridType">网格类型</param>
        /// <param name="condition">条件</param>
        /// <param name="initModule">原始模块，针对表单弹出框</param>
        /// <param name="initField">原始字段，针对表单弹出框</param>
        /// <param name="otherParams">其他参数</param>
        /// <param name="currUser">当前用户</param>
        /// <returns></returns>
        public Expression<Func<OrgM_Emp, bool>> GetGridFilterCondition(out string where, DataGridType gridType, Dictionary<string, string> condition = null, string initModule = null, string initField = null, Dictionary<string, string> otherParams = null, UserInfo currUser = null)
        {
            where = string.Empty;
            if (condition != null && condition.ContainsKey("OrgM_DeptId"))
            {
                OrgM_Dept root = OrgMOperate.GetDeptRoot();
                Guid deptId = condition["OrgM_DeptId"].ObjToGuid();
                if (deptId != root.Id)
                {
                    List<Guid> childDeptIds = OrgMOperate.GetChildDepts(deptId).Select(x => x.Id).ToList();
                    childDeptIds.Add(deptId);
                    string deptIdStr = string.Join("','", childDeptIds);
                    where = string.Format("Id IN(SELECT OrgM_EmpId FROM dbo.OrgM_EmpDeptDuty WHERE OrgM_DeptId IN('{0}'))", deptIdStr);
                    condition.Remove("OrgM_DeptId");
                }
            }
            return null;
        }
        /// <summary>
        /// 操作按钮验证
        /// </summary>
        /// <param name="buttonText">按钮Text</param>
        /// <param name="ids">操作ID集合</param>
        /// <param name="otherParams">其他参数</param>
        /// <param name="currUser">当前用户</param>
        /// <returns></returns>
        public string GridButtonOperateVerify(string buttonText, List<Guid> ids, object[] otherParams = null, UserInfo currUser = null)
        {
            return string.Empty;
        }
        #endregion
        #region 表单处理
        /// <summary>
        /// 表单数据处理
        /// </summary>
        /// <param name="t">对象</param>
        /// <param name="formType">表单类型</param>
        /// <param name="currUser">当前用户</param>
        public void FormDataHandle(OrgM_Emp t, FormTypeEnum formType, UserInfo currUser = null)
        {
            if (t != null)
            {
                OrgM_EmpDeptDuty empPosition = OrgMOperate.GetEmpMainPosition(t.Id);
                if (empPosition != null)
                {
                    if (empPosition.OrgM_DeptId.HasValue && empPosition.OrgM_DeptId.Value != Guid.Empty &&
                        empPosition.OrgM_DutyId.HasValue && empPosition.OrgM_DutyId.Value != Guid.Empty)
                    {
                        OrgM_Dept dept = OrgMOperate.GetDeptById(empPosition.OrgM_DeptId.Value);
                        if (dept != null)
                        {
                            t.DeptId = dept.Id;
                            t.DeptName = string.IsNullOrEmpty(dept.Alias) ? dept.Name : dept.Alias;
                        }
                        OrgM_Duty duty = OrgMOperate.GetDuty(empPosition.OrgM_DutyId.Value);
                        if (duty != null)
                        {
                            t.DutyId = duty.Id;
                            t.DutyName = duty.Name;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取表单按钮
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="buttons"></param>
        /// <param name="isAdd"></param>
        /// <param name="isDraft"></param>
        /// <param name="currUser"></param>
        /// <returns></returns>
        public List<FormButton> GetFormButtons(FormTypeEnum formType, List<FormButton> buttons, bool isAdd = false, bool isDraft = false, UserInfo currUser = null)
        {
            return buttons;
        }
        /// <summary>
        /// 获取表单tags
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="tags"></param>
        /// <param name="isAdd"></param>
        /// <param name="currUser"></param>
        /// <returns></returns>
        public List<FormToolTag> GetFormToolTags(FormTypeEnum formType, List<FormToolTag> tags, bool isAdd = false, UserInfo currUser = null)
        {
            return tags;
        }
        /// <summary>
        /// 获取智能提示模板
        /// </summary>
        /// <param name="t"></param>
        /// <param name="initModule"></param>
        /// <param name="initField"></param>
        /// <param name="otherParams"></param>
        /// <param name="currUser"></param>
        /// <returns></returns>
        public string GetAutoCompleteDisplay(OrgM_Emp t, string initModule, string initField, object[] otherParams = null, UserInfo currUser = null)
        {
            return string.Empty;
        }
        /// <summary>
        /// 自定义保存明细数据
        /// </summary>
        /// <param name="detailObj"></param>
        /// <param name="errMsg"></param>
        /// <param name="currUser"></param>
        /// <returns>返回是否执行了明细保存</returns>
        public bool OverSaveDetailData(DetailFormObject detailObj, out string errMsg, UserInfo currUser = null)
        {
            errMsg = string.Empty;
            return false;
        }
        #endregion
    }
}
