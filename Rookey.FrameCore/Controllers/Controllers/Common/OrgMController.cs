/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookey.Frame.Base;
using Rookey.Frame.Common;
using Rookey.Frame.Controllers.Attr;
using Rookey.Frame.Controllers.Other;
using Rookey.Frame.Model.OrgM;
using Rookey.Frame.Operate.Base;
using Rookey.Frame.Operate.Base.OperateHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookey.Frame.Controllers.OrgM
{
    /// <summary>
    /// 组织机构相关操作控制器（异步）
    /// </summary>
    public class OrgMAsyncController : BaseController
    {
        /// <summary>
        /// 异步获取部门职务
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> GetDeptDutys()
        {
            return Task.Factory.StartNew(() =>
            {
                OrgMController c = new OrgMController();
                c.RequestSet = Request;
                return c.GetDeptDutys();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步获取员工的层级部门信息
        /// </summary>
        /// <returns></returns>
        public Task<JsonResult> GetEmpLevelDepthDept()
        {
            return Task.Factory.StartNew(() =>
            {
                OrgMController c = new OrgMController();
                c.RequestSet = Request;
                return c.GetEmpLevelDepthDept();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }
    }

    /// <summary>
    /// 组织机构相关操作控制器
    /// </summary>
    public class OrgMController : BaseController
    {
        #region 构造函数

        private HttpRequest _Request = null; //请求对象
        public HttpRequest RequestSet { set { _Request = value; } }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OrgMController()
        {
            _Request = Request;
        }

        #endregion

        /// <summary>
        /// 获取部门职务
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult GetDeptDutys()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Guid deptId = _Request.QueryEx("deptId").ObjToGuid();
            List<OrgM_Duty> dutys = OrgMOperate.GetDeptDutys(deptId);
            dutys.Insert(0, new OrgM_Duty() { Id = Guid.Empty, Name = "请选择" });
            return Json(dutys);
        }

        /// <summary>
        /// 获取员工的层级部门信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmpLevelDepthDept()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            string levelDepthStr = _Request.QueryEx("levelDepth").ObjToStr();
            int levelDepth = levelDepthStr.ObjToInt(); //层级
            string empIdStr = _Request.QueryEx("empId").ObjToStr();
            Guid empId = empIdStr.ObjToGuid(); //员工ID
            string companyIdStr = _Request.QueryEx("companyId").ObjToStr();
            Guid? companyId = companyIdStr.ObjToGuidNull(); //所属公司，集团模式下用到
            string deptIdStr = _Request.QueryEx("deptId").ObjToStr();
            Guid? deptId = deptIdStr.ObjToGuidNull(); //兼职部门，以兼职部门找
            if (empId == Guid.Empty || levelDepth < 0)
                return Json(null);
            //层级部门
            OrgM_Dept depthDept = OrgMOperate.GetEmpLevelDepthDept(levelDepth, empId, companyId, deptId);
            //当前部门
            OrgM_Dept currDept = deptId.HasValue && deptId.Value != Guid.Empty ? OrgMOperate.GetDeptById(deptId.Value) : OrgMOperate.GetEmpMainDept(empId, companyId);
            return Json(new { CurrDept = currDept, DepthDept = depthDept });
        }

        /// <summary>
        /// 上传员工照片，照片路径/Upload/
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadEmpPhoto()
        {
            string idStr = Request.QueryEx("id").ObjToStr();
            Guid id = idStr.ObjToGuid();
            string filePath = Request.QueryEx("filePath").ObjToStr();
            string errMsg = string.Empty;
            if (id != Guid.Empty && !string.IsNullOrWhiteSpace(filePath))
            {
                string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                filePath = filePath.Replace("/", pathFlag);
                if (filePath.StartsWith(pathFlag))
                    filePath = filePath.Substring(pathFlag.Length, filePath.Length - pathFlag.Length);
                filePath = Globals.GetWebDir() + filePath;
                string dir = Globals.GetWebDir() + "Upload" + pathFlag + "Image" + pathFlag + "Emp";
                try
                {
                    if (!System.IO.Directory.Exists(dir))
                        System.IO.Directory.CreateDirectory(dir);
                    string newFile = dir + pathFlag + id.ToString() + System.IO.Path.GetExtension(filePath);
                    System.IO.File.Copy(filePath, newFile, true);
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                }
            }
            return Json(new ReturnResult() { Success = string.IsNullOrEmpty(errMsg), Message = errMsg });
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <returns></returns>
        public JsonResult AddDept()
        {
            if (_Request == null) _Request = Request;
            string deptname = _Request.QueryEx("deptname").ObjToStr();
            if (string.IsNullOrWhiteSpace(deptname))
                return Json(new ReturnResult() { Success = false, Message = "部门名称不能为空" });
            string errMsg = string.Empty;
            long num = CommonOperate.Count<OrgM_Dept>(out errMsg, false, x => x.Name == deptname);
            if (num > 0)
                return Json(new ReturnResult() { Success = false, Message = "该部门已存在，请不要重复添加" });
            UserInfo currUser = GetCurrentUser(_Request);
            Guid moduleId = SystemOperate.GetModuleIdByTableName("OrgM_Dept");
            string code = SystemOperate.GetBillCode(moduleId);
            OrgM_Dept dept = new OrgM_Dept()
            {
                Code = code,
                Name = deptname,
                Alias = deptname,
                IsValid = true,
                EffectiveDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreateUserId = currUser.UserId,
                CreateUserName = currUser.EmpName,
                ModifyDate = DateTime.Now,
                ModifyUserId = currUser.UserId,
                ModifyUserName = currUser.EmpName
            };
            Guid deptId = CommonOperate.OperateRecord<OrgM_Dept>(dept, ModelRecordOperateType.Add, out errMsg, null, false);
            if (deptId != Guid.Empty)
            {
                SystemOperate.UpdateBillCode(moduleId, code);
                return Json(new { Success = true, Message = string.Empty, DeptId = deptId, DeptName = deptname });
            }
            else
            {
                return Json(new ReturnResult() { Success = false, Message = errMsg });
            }
        }

        /// <summary>
        /// 添加职务
        /// </summary>
        /// <returns></returns>
        public JsonResult AddDuty()
        {
            if (_Request == null) _Request = Request;
            Guid deptId = _Request.QueryEx("deptId").ObjToGuid();
            if (deptId == Guid.Empty)
                return Json(new ReturnResult() { Success = false, Message = "请先选择部门" });
            OrgM_Dept dept = OrgMOperate.GetDeptById(deptId);
            if (dept == null)
                return Json(new ReturnResult() { Success = false, Message = "选择的部门不存在" });
            string dutyname = _Request.QueryEx("dutyname").ObjToStr();
            if (string.IsNullOrWhiteSpace(dutyname))
                return Json(new ReturnResult() { Success = false, Message = "职务名称不能为空" });
            string errMsg = string.Empty;
            long num = CommonOperate.Count<OrgM_Dept>(out errMsg, false, x => x.Name == dutyname);
            if (num > 0)
                return Json(new ReturnResult() { Success = false, Message = "该职务已存在，请不要重复添加" });
            UserInfo currUser = GetCurrentUser(_Request);
            Guid moduleId = SystemOperate.GetModuleIdByTableName("OrgM_Duty");
            string code = SystemOperate.GetBillCode(moduleId);
            OrgM_Duty duty = new OrgM_Duty()
            {
                Code = code,
                Name = dutyname,
                IsValid = true,
                EffectiveDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreateUserId = currUser.UserId,
                CreateUserName = currUser.EmpName,
                ModifyDate = DateTime.Now,
                ModifyUserId = currUser.UserId,
                ModifyUserName = currUser.EmpName
            };
            Guid dutyId = CommonOperate.OperateRecord<OrgM_Duty>(duty, ModelRecordOperateType.Add, out errMsg, null, false);
            if (dutyId != Guid.Empty)
            {
                SystemOperate.UpdateBillCode(moduleId, code);
                Guid? parentId = null;
                List<OrgM_DeptDuty> positions = OrgMOperate.GetDeptPositions(deptId);
                if (positions.Count > 0)
                {
                    OrgM_DeptDuty leaderPosition = positions.Where(x => x.IsDeptCharge).FirstOrDefault();
                    if (leaderPosition != null)
                        parentId = leaderPosition.Id;
                }
                Guid gwModuleId = SystemOperate.GetModuleIdByTableName("OrgM_DeptDuty");
                string positionCode = SystemOperate.GetBillCode(gwModuleId);
                OrgM_DeptDuty position = new OrgM_DeptDuty()
                {
                    Code = positionCode,
                    Name = string.Format("{0}-{1}", string.IsNullOrEmpty(dept.Alias) ? dept.Name : dept.Alias, dutyname),
                    OrgM_DeptId = deptId,
                    OrgM_DutyId = dutyId,
                    ParentId = parentId,
                    IsValid = true
                };
                Guid positionId = CommonOperate.OperateRecord<OrgM_DeptDuty>(position, ModelRecordOperateType.Add, out errMsg, null, false);
                if (positionId != Guid.Empty)
                    SystemOperate.UpdateBillCode(gwModuleId, positionCode);
                return Json(new { Success = true, Message = string.Empty, DutyId = dutyId });
            }
            else
            {
                return Json(new ReturnResult() { Success = false, Message = errMsg });
            }
        }
    }
}
