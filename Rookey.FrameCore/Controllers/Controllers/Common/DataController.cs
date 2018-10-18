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
using Rookey.Frame.Base.Set;
using Rookey.Frame.Common;
using Rookey.Frame.Controllers.Attr;
using Rookey.Frame.Controllers.Other;
using Rookey.Frame.EntityBase;
using Rookey.Frame.Model.EnumSpace;
using Rookey.Frame.Model.OrgM;
using Rookey.Frame.Model.Sys;
using Rookey.Frame.Operate.Base;
using Rookey.Frame.Operate.Base.EnumDef;
using Rookey.Frame.Operate.Base.Extension;
using Rookey.Frame.Operate.Base.OperateHandle;
using Rookey.Frame.Operate.Base.TempModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rookey.Frame.Controllers
{
    /// <summary>
    /// 公共通用数据控制器（异步）
    /// </summary>
    public class DataAsyncController : BaseController
    {
        #region 通用树

        /// <summary>
        /// 异步加载树（结点方式）
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> GetTreeByNode()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.GetTreeByNode();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 通用列表

        /// <summary>
        /// 异步通用分页数据加载
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> LoadGridData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.LoadGridData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步导出模块数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> ExportModelData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.ExportModelData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步列表工具栏操作验证
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> GridOperateVerify()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.GridOperateVerify();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 通用保存

        /// <summary>
        /// 异步通用保存数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> SaveData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.SaveData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 通用删除

        /// <summary>
        /// 异步通用删除，单条记录，多条记录删除均适用
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> Delete()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.Delete();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步通用还原，单条记录，多条记录删除均适用
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> Restore()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.Restore();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 表单处理

        /// <summary>
        /// 异步表单数据加载
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> LoadFormData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.LoadFormData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步加载模块数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> LoadModuleDatas()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.LoadModuleDatas();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步更新字段值
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> UpdateField()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.UpdateField();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步批量更新字段值
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BatchUpdate()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BatchUpdate();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步下载导入模板
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<ActionResult> DownImportTemplate()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.DownImportTemplate();
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步导入实体数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> ImportModelData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.ImportModelData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 通用下拉框数据绑定

        /// <summary>
        /// 绑定枚举字段下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BindEnumFieldData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BindEnumFieldData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 绑定外键字段下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BindForeignFieldComboData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BindForeignFieldComboData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 绑定下拉框字典数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BindDictionaryData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BindDictionaryData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }


        /// <summary>
        /// 绑定下级字典，参数为模块Id或模块名称、字段名、字典值
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BindChildDictionary()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BindChildDictionary();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 绑定字段已存在的值为下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BindExistsFieldValueData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BindExistsFieldValueData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 绑定模块下拉框数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<JsonResult> BindModuleComboData()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.BindModuleComboData();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 辅助功能

        /// <summary>
        /// 自动完成功能
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public Task<ActionResult> AutoComplete()
        {
            return Task.Factory.StartNew(() =>
            {
                DataController c = new DataController();
                c.RequestSet = Request;
                return c.AutoComplete();
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion
    }

    /// <summary>
    /// 公共通用数据控制器
    /// </summary>
    public class DataController : BaseController
    {
        #region 构造函数

        private HttpRequest _Request = null; //请求对象
        public HttpRequest RequestSet { set { _Request = value; } }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public DataController()
        {
            _Request = Request;
        }

        #endregion

        #region 通用树

        /// <summary>
        /// 加载树（结点方式）
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult GetTreeByNode()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(null);
            Type modelType = CommonOperate.GetModelType(module.Id);
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
            if (!string.IsNullOrWhiteSpace(fieldName)) //按字段组成一级树
            {
                string q = _Request.QueryEx("q").ObjToStr(); //查询字符
                string errMsg = string.Empty;
                bool isForeignNameField = SystemOperate.IsForeignNameField(module.Id, fieldName);
                if (SystemOperate.IsForeignField(module.Id, fieldName) || isForeignNameField) //外键字段
                {
                    if (isForeignNameField) fieldName = fieldName.Substring(0, fieldName.Length - 4) + "Id";
                    //外键模块对象
                    Sys_Module foreignModule = SystemOperate.GetForeignModule(module.Id, fieldName);
                    Type foreignModuleType = CommonOperate.GetModelType(foreignModule.Id);
                    string qWhere = !string.IsNullOrEmpty(q) ? string.Format(" AND {0} LIKE '%{1}%'", foreignModule.TitleKey, q) : string.Empty;
                    string sql = string.Format("SELECT Id,{0} FROM {1} WHERE Id IN(SELECT {2} FROM {3} WHERE {2} IS NOT NULL GROUP BY {2}){4}", foreignModule.TitleKey, ModelConfigHelper.GetModuleTableName(foreignModuleType), fieldName, ModelConfigHelper.GetModuleTableName(modelType), qWhere);
                    DataTable dt = CommonOperate.ExecuteQuery(out errMsg, sql);
                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    {
                        List<TreeNode> list = dt.Rows.Cast<DataRow>().Select(x => new TreeNode() { id = x[0].ObjToGuid().ToString(), text = x[1].ObjToStr() }).ToList();
                        list.Insert(0, new TreeNode() { id = Guid.Empty.ToString(), text = "全部" });
                        return Json(list);
                    }
                }
                else if (SystemOperate.IsEnumField(module.Id, fieldName)) //枚举字段
                {
                    Dictionary<string, string> dic = CommonOperate.GetFieldEnumTypeList(module.Id, fieldName);
                    List<TreeNode> list = new List<TreeNode>();
                    list.Add(new TreeNode() { id = "-1", text = "全部" });
                    List<TreeNode> tempList = dic.Select(x => new TreeNode() { id = x.Value, text = x.Key }).ToList();
                    if (!string.IsNullOrEmpty(q))
                        tempList = tempList.Where(x => x.text.Contains(q)).ToList();
                    return Json(list);
                }
                else if (SystemOperate.IsDictionaryBindField(module.Id, fieldName)) //字典字段
                {
                    List<Sys_Dictionary> dics = SystemOperate.GetDictionaryData(module.Id, fieldName);
                    if (!string.IsNullOrEmpty(q))
                        dics = dics.Where(x => x.Name.Contains(q)).ToList();
                    List<TreeNode> list = new List<TreeNode>();
                    list.Add(new TreeNode() { id = "-1", text = "全部" });
                    if (dics != null && dics.Count > 0)
                    {
                        List<TreeNode> tempList = dics.Select(x => new TreeNode() { id = x.Id.ToString(), text = x.Name }).ToList();
                        if (tempList != null) list.AddRange(tempList);
                    }
                    return Json(list);
                }
                else //普通字符串字段
                {
                    string hasIdStr = _Request.QueryEx("hasId").ObjToStr();
                    bool hasId = hasIdStr.ObjToInt() == 1; //是否包含ID
                    string qWhere = !string.IsNullOrEmpty(q) ? string.Format(" AND {0} LIKE '%{1}%'", fieldName, q) : string.Empty;
                    string tempFieldName = fieldName;
                    if (hasId)
                        tempFieldName = string.Format("Id,{0}", fieldName);
                    string sql = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {3} IS NOT NULL{2} GROUP BY {0}", tempFieldName, ModelConfigHelper.GetModuleTableName(modelType), qWhere, fieldName);
                    List<TreeNode> list = new List<TreeNode>();
                    if (!hasId)
                        list.Add(new TreeNode() { id = "-1", text = "全部" });
                    DataTable dt = CommonOperate.ExecuteQuery(out errMsg, sql);
                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    {
                        List<TreeNode> tempList = hasId ? dt.Rows.Cast<DataRow>().Where(x => !string.IsNullOrWhiteSpace(x[0].ObjToStr())).Select(x => new TreeNode() { id = x[0].ObjToStr(), text = x[1].ObjToStr() }).ToList() :
                                                 dt.Rows.Cast<DataRow>().Where(x => !string.IsNullOrWhiteSpace(x[0].ObjToStr())).Select(x => new TreeNode() { text = x[0].ObjToStr() }).ToList();
                        if (tempList != null) list.AddRange(tempList);
                    }
                    return Json(list);
                }
                return Json(null);
            }
            else //多级树
            {
                //父结点Id
                string parentIdStr = _Request.QueryEx("parentId").ObjToStr();
                Guid parentId = parentIdStr.ObjToGuid(); //指定根节点
                Guid tempId = _Request.QueryEx("id").ObjToGuid();
                if (tempId != Guid.Empty) parentId = tempId;
                string norootStr = _Request.QueryEx("noRoot").ObjToStr();
                bool noRoot = norootStr.ObjToInt() == 1; //是否去掉根结点
                string asyncStr = _Request.QueryEx("async").ObjToStr();
                bool isAsync = asyncStr.ObjToInt() == 1; //是否异步
                if (tempId != Guid.Empty && isAsync)
                    noRoot = true;
                object action = null; //扩展属性参数
                string sortIdStr = _Request.QueryEx("sortField").ObjToStr();
                string sortId = sortIdStr.ObjToStr(); //排序字段
                if (string.IsNullOrEmpty(sortId)) sortId = "Id";
                string icon = _Request.QueryEx("icon").ObjToStr(); //图标样式类
                string q = _Request.QueryEx("q").ObjToStr(); //查询字符
                if (module.Name == "菜单管理")
                {
                    action = new Action<Sys_Menu, TreeAttributes>((obj, attribute) =>
                    {
                        attribute.obj = new { moduleId = obj.Sys_ModuleId, moduleName = obj.Sys_ModuleName, isNewWinOpen = obj.IsNewWinOpen };
                    });
                    sortId = "Sort";
                }
                TreeNode node = null;
                switch (module.Name)
                {
                    case "部门管理":
                        {
                            Expression<Func<OrgM_Dept, bool>> exp = null;
                            if (!string.IsNullOrEmpty(q))
                                exp = x => x.Alias.Contains(q);
                            node = OrgMOperate.LoadDeptTree(parentId, exp, isAsync);
                        }
                        break;
                    case "岗位管理":
                        {
                            Expression<Func<OrgM_DeptDuty, bool>> exp = null;
                            if (!string.IsNullOrEmpty(q))
                                exp = x => x.Name.Contains(q);
                            node = OrgMOperate.LoadPositionTree(parentId, exp, isAsync);
                        }
                        break;
                    case "员工管理":
                        {
                            Expression<Func<OrgM_Emp, bool>> exp = null;
                            if (!string.IsNullOrEmpty(q))
                                exp = x => x.Name.Contains(q);
                            node = OrgMOperate.LoadDeptEmpTree(parentId, isAsync, exp);
                        }
                        break;
                    case "用户管理":
                        {
                            Expression<Func<Sys_User, bool>> exp = null;
                            if (!string.IsNullOrEmpty(q))
                                exp = x => x.UserName.Contains(q);
                            node = UserOperate.LoadOrgUserTree(parentId, isAsync, exp);
                        }
                        break;
                    default:
                        {
                            string pIdFieldName = _Request.QueryEx("pIdFieldName").ObjToStr();
                            string textName = _Request.QueryEx("textName").ObjToStr();
                            object exp = null;
                            if (!string.IsNullOrEmpty(q))
                            {
                                List<ConditionItem> items = new List<ConditionItem>() { new ConditionItem() { Field = string.IsNullOrEmpty(textName) ? "Name" : textName, Method = QueryMethod.Like, Value = q } };
                                exp = CommonOperate.GetQueryCondition(module.Id, items);
                            }
                            node = CommonOperate.GetTreeNode(module.Id, parentId, action, pIdFieldName, textName, sortId, icon, exp, null, null, isAsync, GetCurrentUser(_Request));
                        }
                        break;
                }
                if (node == null) return Json(node);
                return noRoot ? Json(node.children.ToJson().Content) : Json(node);
            }
        }

        #endregion

        #region 通用列表

        /// <summary>
        /// 通用分页数据加载
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult LoadGridData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            GridDataParmas gridDataParams = CommonOperate.GetGridDataParams(_Request);
            UserInfo currUser = GetCurrentUser(_Request);
            long total = 0;
            object list = CommonOperate.GetGridData(gridDataParams, out total, currUser);
            //返回结果
            var result = (list as IEnumerable).Paged(total);
            //添加操作日志
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, SystemOperate.GetModuleNameById(gridDataParams.ModuleId), "查看列表", string.Empty, true, string.Empty);
            });
            return result;
        }

        /// <summary>
        /// 导出模块数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult ExportModelData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            GridDataParmas gridParams = CommonOperate.GetGridDataParams(_Request);
            UserInfo currUser = GetCurrentUser(_Request);
            if (currUser == null)
            {
                return Json(new ExportReturnResult() { Success = false, Message = "您没有该模块的导出权限，如有疑问请联系管理员！" });
            }
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            if (gridParams.GridViewId.HasValue)
            {
                Sys_Grid grid = SystemOperate.GetGrid(gridParams.GridViewId.Value);
                if (grid != null && (grid.GridTypeOfEnum == GridTypeEnum.Comprehensive || grid.GridTypeOfEnum == GridTypeEnum.ComprehensiveDetail))
                {
                    gridParams.ViewId = grid.Id;
                    if (grid.GridTypeOfEnum == GridTypeEnum.ComprehensiveDetail)
                        gridParams.IsComprehensiveDetailView = true;
                }
            }
            gridParams.IsExportData = true;
            string vidStr = _Request.QueryEx("vId").ObjToStr();
            Guid? vId = vidStr.ObjToGuidNull();
            gridParams.PagingInfo.pagesize = GlobalSet.ExportDataPagingSize;
            string errMsg = string.Empty;
            string fileName = string.Format("{0}Upload{4}Temp{4}{1}{4}{2}_{3}.xls", Globals.GetWebDir(), DateTime.Now.ToString("yyyyMM"), SystemOperate.GetModuleNameById(gridParams.ModuleId), DateTime.Now.ToString("yyyyMMddHHmmss"), pathFlag);
            errMsg = CommonOperate.ExportData(gridParams, currUser, fileName, vId);
            string downUrl = string.Format("/Annex/DownloadFile.html?fileName={0}", HttpUtility.UrlEncode(fileName, Encoding.UTF8));
            //添加操作日志
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, gridParams.ModuleId, "导出数据", JsonHelper.Serialize(new { DataFile = fileName }), string.IsNullOrEmpty(errMsg), errMsg);
            });
            //返回数据
            return Json(new ExportReturnResult() { Success = string.IsNullOrEmpty(errMsg), Message = errMsg, DownUrl = downUrl });
        }

        /// <summary>
        /// 列表工具栏操作验证
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult GridOperateVerify()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null)
                return Json(new ReturnResult() { Success = false, Message = "模块不存在！" });
            string btStr = _Request.QueryEx("buttonText").ObjToStr();
            string buttonText = HttpUtility.UrlDecode(btStr, Encoding.UTF8);
            string ids = _Request.QueryEx("ids").ObjToStr();
            string otherParams = _Request.QueryEx("otherParams").ObjToStr(); //其他参数
            if (string.IsNullOrEmpty(buttonText))
                return Json(new ReturnResult() { Success = false, Message = "按钮显示名称不能为空！" });
            UserInfo currUser = GetCurrentUser(_Request);
            List<Guid> listIds = new List<Guid>();
            bool isEnableFlow = BpmOperate.IsEnabledWorkflow(module.Id);
            if (!string.IsNullOrEmpty(ids))
            {
                string tempMsg = string.Empty;
                string[] token = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in token)
                {
                    Guid id = str.ObjToGuid();
                    if (id == Guid.Empty)
                        continue;
                    listIds.Add(id);
                    if (buttonText == "编辑" || buttonText == "删除" || buttonText == "提交")
                    {
                        if (buttonText == "编辑" && module.ParentId.HasValue && module.ParentId.Value != Guid.Empty && isEnableFlow)
                        {
                            //明细模块记录流程启动后非当前待办人不能编辑
                            Guid todoId = otherParams.ObjToGuid();
                            if (todoId != Guid.Empty && BpmOperate.IsCurrentToDoTaskHandler(todoId, currUser)) //为当前待办人审批时跳过流程验证
                            {
                                continue;
                            }
                        }
                        if (isEnableFlow)
                        {
                            WorkFlowStatusEnum flowStatus = BpmOperate.GetRecordFlowStatus(module.Id, id);
                            WorkFlowStatusEnum recoredStatus = BpmOperate.GetRecordStatus(module.Id, id);
                            if (flowStatus != WorkFlowStatusEnum.NoStatus || (recoredStatus != WorkFlowStatusEnum.NoStatus && recoredStatus != WorkFlowStatusEnum.Customer))
                            {
                                if (flowStatus == WorkFlowStatusEnum.NoStatus) flowStatus = recoredStatus;
                                string msgDes = string.Format("{0}的单据不允许{1}！", EnumHelper.GetDescription(typeof(WorkFlowStatusEnum), flowStatus), buttonText);
                                return Json(new ReturnResult() { Success = false, Message = msgDes });
                            }
                        }
                        if (buttonText == "提交")
                        {
                            object modelObj = CommonOperate.GetEntityById(module.Id, id, out tempMsg, new List<string>() { "CreateUserId" });
                            BaseEntity baseModel = modelObj as BaseEntity;
                            if (baseModel == null)
                                return Json(new ReturnResult() { Success = false, Message = "单据出现异常无法提交流程" });
                            if (baseModel.CreateUserId != currUser.UserId)
                                return Json(new ReturnResult() { Success = false, Message = "您不是该单据的创建者无法提交流程" });
                        }
                    }
                    else if (buttonText == "重新发起" && isEnableFlow)
                    {
                        if (!PermissionOperate.HasButtonPermission(currUser, module.Id, "新增"))
                            return Json(new ReturnResult() { Success = false, Message = "您没有该模块的新增权限无法重新发起" });
                        object modelObj = CommonOperate.GetEntityById(module.Id, id, out tempMsg, new List<string>() { "CreateUserId" });
                        BaseEntity baseModel = modelObj as BaseEntity;
                        if (baseModel == null)
                            return Json(new ReturnResult() { Success = false, Message = "原始记录不存在无法重新发起" });
                        if (baseModel.CreateUserId != currUser.UserId)
                            return Json(new ReturnResult() { Success = false, Message = "您不是该单据的创建者无法重新发起" });
                        WorkFlowStatusEnum flowStatus = BpmOperate.GetRecordFlowStatus(module.Id, id);
                        WorkFlowStatusEnum recoredStatus = BpmOperate.GetRecordStatus(module.Id, id);
                        if (flowStatus != WorkFlowStatusEnum.Refused || recoredStatus != WorkFlowStatusEnum.Refused)
                        {
                            return Json(new ReturnResult() { Success = false, Message = "只有被拒绝的单据才能重新发起" });
                        }
                    }
                }
            }
            else if ((buttonText == "新增" || buttonText == "复制") && !string.IsNullOrEmpty(otherParams) &&
                    SystemOperate.IsDetailModule(module.Id) && isEnableFlow)
            {
                otherParams = otherParams.Replace("#", string.Empty);
                string[] token = otherParams.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (token.Length == 2)
                {
                    Guid mainModuleId = token[0].ObjToGuid(); //主模块ID
                    Guid mainRecordId = token[1].ObjToGuid(); //主模块记录ID
                    if (mainModuleId != Guid.Empty && mainRecordId != Guid.Empty)
                    {
                        WorkFlowStatusEnum flowStatus = BpmOperate.GetRecordFlowStatus(mainModuleId, mainRecordId);
                        WorkFlowStatusEnum recoredStatus = BpmOperate.GetRecordStatus(mainModuleId, mainRecordId);
                        if (flowStatus != WorkFlowStatusEnum.NoStatus || (recoredStatus != WorkFlowStatusEnum.NoStatus && recoredStatus != WorkFlowStatusEnum.Customer))
                        {
                            string moduleDisplay = string.IsNullOrEmpty(module.Display) ? module.Name : module.Display;
                            string msgDes = string.Format("{0}的主单据不允许{1}【{2}】！", EnumHelper.GetDescription(typeof(WorkFlowStatusEnum), flowStatus), buttonText, moduleDisplay);
                            return Json(new ReturnResult() { Success = false, Message = msgDes });
                        }
                    }
                }
            }
            string errMsg = CommonOperate.GridOperateVerify(module.Id, buttonText, listIds, currUser);
            return Json(new ReturnResult() { Success = string.IsNullOrEmpty(errMsg), Message = errMsg });
        }

        #endregion

        #region 通用保存

        /// <summary>
        /// 通用保存数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult SaveData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            #region 参数定义
            UserInfo currUser = GetCurrentUser(_Request); //当前用户
            string errMsg = string.Empty;
            string nsStr = _Request.QueryEx("nosave").ObjToStr();
            bool isNoSave = nsStr.ObjToInt() == 1; //针对流程不保存表单标识
            //以下为流程相关参数
            Guid? opFlowBtnId = null; //操作动作
            Guid? toDoTaskId = null; //待办ID
            string approvalOpinions = string.Empty; //审批意见
            Guid? returnNodeId = null; //回退结点ID
            bool isReturnBack = false; //退回节点审批后直接回到当前审批节点
            Guid? directHandler = null; //指派人ID
            string childTodoIds = null; //子流程待办ID集合
            string startFlow = null; //指定版本的流程名称
            #endregion
            string dtStr = _Request.QueryEx("formData").ObjToStr();
            string formData = HttpUtility.UrlDecode(MySecurity.DecodeBase64(dtStr), Encoding.UTF8).Replace("%20", "+");
            if (!isNoSave) //需要保存表单
            {
                #region 保存表单并且处理流程
                Guid rs = Guid.Empty; //保存返回值
                string moduleName = string.Empty;
                Guid moduleId = Guid.Empty;
                string ntStr = _Request.QueryEx("noTran").ObjToStr();
                bool isNoTran = ntStr.ObjToInt() == 1; //是否不启用事务保存
                string nfStr = _Request.QueryEx("noFast").ObjToStr();
                bool isNoFastSave = nfStr.ObjToInt() == 1; //是否用非快速保存方法
                if (isNoFastSave && isNoTran) //采用非快速保存方法
                {
                    FormDataObject formObj = JsonHelper.Deserialize<FormDataObject>(formData);
                    rs = CommonOperate.SaveRecord(currUser, formObj, out errMsg);
                    moduleId = formObj.ModuleId.Value;
                    moduleName = formObj.ModuleName;
                    //流程参数斌值
                    if (rs != Guid.Empty)
                    {
                        opFlowBtnId = formObj.OpFlowBtnId;
                        toDoTaskId = formObj.ToDoTaskId;
                        approvalOpinions = formObj.ApprovalOpinions;
                        returnNodeId = formObj.ReturnNodeId;
                        isReturnBack = formObj.IsReturnBack;
                        directHandler = formObj.DirectHandler;
                        childTodoIds = formObj.ChildTodoIds;
                        startFlow = formObj.StartFlow;
                    }
                }
                else //调用快速保存方法
                {
                    FormFastObject formFastObj = JsonHelper.Deserialize<FormFastObject>(formData);
                    rs = CommonOperate.FastSave(currUser, formFastObj, out errMsg, !isNoTran);
                    moduleId = formFastObj.ModuleId.Value;
                    moduleName = formFastObj.ModuleName;
                    //流程参数斌值
                    if (rs != Guid.Empty)
                    {
                        opFlowBtnId = formFastObj.OpFlowBtnId;
                        toDoTaskId = formFastObj.ToDoTaskId;
                        approvalOpinions = formFastObj.ApprovalOpinions;
                        returnNodeId = formFastObj.ReturnNodeId;
                        isReturnBack = formFastObj.IsReturnBack;
                        directHandler = formFastObj.DirectHandler;
                        childTodoIds = formFastObj.ChildTodoIds;
                        startFlow = formFastObj.StartFlow;
                    }
                }
                //添加操作日志
                Task.Factory.StartNew(() =>
                {
                    LogOperate.AddOperateLog(currUser, moduleName, "表单保存", formData, rs != Guid.Empty, errMsg);
                });
                //处理流程
                if (rs != Guid.Empty && opFlowBtnId.HasValue && BpmOperate.IsEnabledWorkflow(moduleId))
                {
                    BpmAsyncController c = new BpmAsyncController();
                    c.RequestSet = _Request;
                    //处理流程
                    if (toDoTaskId.HasValue && toDoTaskId.Value != Guid.Empty)
                    {
                        ReturnNodeInfo returnNode = null;
                        if (returnNodeId.HasValue && returnNodeId.Value != Guid.Empty)
                            returnNode = new ReturnNodeInfo() { ReturnNode = BpmOperate.GetWorkNode(returnNodeId.Value), IsReturnBack = isReturnBack };
                        return c.HandleOpProcess(toDoTaskId.Value, approvalOpinions, opFlowBtnId.Value, returnNode, directHandler, childTodoIds).Result;
                    }
                    else
                    {
                        return c.StartProcess(moduleId, rs, startFlow).Result;
                    }
                }
                //返回数据
                return Json(new SaveDataReturnResult() { Success = rs != Guid.Empty, Message = errMsg, RecordId = rs });
                #endregion
            }
            else //不需要保存表单直接处理流程
            {
                #region 直接处理流程
                FormFastObject formFastObj = JsonHelper.Deserialize<FormFastObject>(formData);
                Guid moduleId = formFastObj.ModuleId.HasValue && formFastObj.ModuleId.Value != Guid.Empty ? formFastObj.ModuleId.Value : SystemOperate.GetModuleIdByName(formFastObj.ModuleName);
                if (BpmOperate.IsEnabledWorkflow(moduleId))
                {
                    opFlowBtnId = formFastObj.OpFlowBtnId;
                    toDoTaskId = formFastObj.ToDoTaskId;
                    approvalOpinions = formFastObj.ApprovalOpinions;
                    returnNodeId = formFastObj.ReturnNodeId;
                    isReturnBack = formFastObj.IsReturnBack;
                    directHandler = formFastObj.DirectHandler;
                    childTodoIds = formFastObj.ChildTodoIds;
                    if (opFlowBtnId.HasValue && toDoTaskId.HasValue && toDoTaskId.Value != Guid.Empty)
                    {
                        BpmAsyncController c = new BpmAsyncController();
                        c.RequestSet = _Request;
                        ReturnNodeInfo returnNode = null;
                        if (returnNodeId.HasValue && returnNodeId.Value != Guid.Empty)
                            returnNode = new ReturnNodeInfo() { ReturnNode = BpmOperate.GetWorkNode(returnNodeId.Value), IsReturnBack = isReturnBack };
                        return c.HandleOpProcess(toDoTaskId.Value, approvalOpinions, opFlowBtnId.Value, returnNode, directHandler, childTodoIds).Result;
                    }
                    else
                    {
                        return Json(new SaveDataReturnResult() { Success = false, Message = "流程参数错误，操作失败", RecordId = Guid.Empty });
                    }
                }
                else
                {
                    return Json(new SaveDataReturnResult() { Success = false, Message = "该模块未启用工作流，参数设置错误", RecordId = Guid.Empty });
                }
                #endregion
            }
        }

        #endregion

        #region 通用删除

        /// <summary>
        /// 通用删除，单条记录，多条记录删除均适用
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult Delete()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            UserInfo currUser = GetCurrentUser(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(new ReturnResult() { Success = false, Message = "模块不存在！" });
            if (currUser == null)
            {
                return Json(new ReturnResult() { Success = false, Message = string.Format("您没有模块【{0}】的删除权限，如有疑问请联系管理员！", module.Name) });
            }
            string ids = _Request.QueryEx("ids").ObjToStr();
            if (string.IsNullOrEmpty(ids))
                return Json(new ReturnResult { Success = false, Message = "删除记录Id参数不能为空！" });
            List<Guid> idList = new List<Guid>(); //要删除的id集合
            string[] token = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            idList = token.Select(x => x.ObjToGuid()).Where(x => x != Guid.Empty).ToList();
            if (idList == null || idList.Count == 0)
                return Json(new ReturnResult { Success = false, Message = "删除记录Id参数不能为空！" });
            string rcStr = _Request.QueryEx("recycle").ObjToStr();
            bool isRecycle = rcStr.ObjToInt() == 1; //是否来自回收站
            string hdStr = _Request.QueryEx("isHardDel").ObjToStr();
            bool isHardDel = hdStr.ObjToInt() == 1; //是否需要硬删除
            bool isSoftDel = !isHardDel && !isRecycle && module.IsEnabledRecycle; //是否软删除
            string errMsg = string.Empty;
            bool rs = CommonOperate.DeleteRecords(module.Id, idList, out errMsg, isSoftDel, true, null, null, null, currUser);
            //添加操作日志
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, module.Name, string.Format("删除记录（{0}）", isSoftDel ? "软删除" : "硬删除"), JsonHelper.Serialize(new { ids = ids }), rs, errMsg);
            });
            if (rs) //触发事件
                SystemOperate.TriggerEventNotify(module.Id, idList, ModelRecordOperateType.Del, currUser);
            //返回数据
            return Json(new ReturnResult() { Success = rs, Message = errMsg });
        }

        /// <summary>
        /// 通用还原，单条记录，多条记录删除均适用
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult Restore()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(new ReturnResult() { Success = false, Message = "模块不存在！" });
            UserInfo currUser = GetCurrentUser(_Request);
            if (currUser == null)
            {
                return Json(new ReturnResult() { Success = false, Message = string.Format("您没有模块【{0}】的数据还原权限，如有疑问请联系管理员！", module.Name) });
            }
            string ids = _Request.QueryEx("ids").ObjToStr();
            if (string.IsNullOrEmpty(ids))
                return Json(new ReturnResult() { Success = false, Message = "还原记录Id参数不能为空！" });
            string errMsg = string.Empty;
            Array arr = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.ObjToGuid()).ToArray();
            List<ConditionItem> conditions = new List<ConditionItem>() { new ConditionItem() { Field = "Id", Method = QueryMethod.In, Value = arr } };
            object expression = CommonOperate.GetQueryCondition(module.Id, conditions);
            bool rs = CommonOperate.UpdateRecordsByExpression(module.Id, new { IsDeleted = false, ModifyDate = DateTime.Now, ModifyUserId = currUser.UserId }, expression, out errMsg);
            if (rs)
            {
                try
                {
                    Type modelType = CommonOperate.GetModelType(module.TableName);
                    PropertyInfo pid = modelType.GetProperty("Id");
                    foreach (Guid id in arr)
                    {
                        object obj = Activator.CreateInstance(modelType);
                        pid.SetValue2(obj, id, null);
                        CommonOperate.ExecuteCustomeOperateHandleMethod(module.Id, "OperateCompeletedHandle", new object[] { ModelRecordOperateType.Restore, obj, true, currUser, null });
                    }
                }
                catch { }
            }
            //添加操作日志
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, module.Name, "还原记录", JsonHelper.Serialize(new { ids = ids }), rs, errMsg);
            });
            //返回数据
            return Json(new ReturnResult() { Success = rs, Message = errMsg });
        }

        #endregion

        #region 表单处理

        /// <summary>
        /// 表单数据加载
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult LoadFormData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(null);
            Guid id = _Request.QueryEx("id").ObjToGuid();
            if (id == Guid.Empty) return Json(null);
            string errMsg = string.Empty;
            object model = CommonOperate.GetEntityById(module.Id, id, out errMsg);
            return Json(model);
        }

        /// <summary>
        /// 加载模块数据
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadModuleDatas()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(null);
            string ids = _Request.QueryEx("ids").ObjToStr(); //记录Id集合，以逗号分隔
            if (string.IsNullOrEmpty(ids)) return Json(null);
            string errMsg = string.Empty;
            List<string> tempIds = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            object models = CommonOperate.GetEntities(out errMsg, module.Id, null, string.Format("Id IN('{0}')", string.Join("','", tempIds)), false);
            return Json(models);
        }

        /// <summary>
        /// 更新字段值
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult UpdateField()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Guid moduleId = _Request.QueryEx("moduleId").ObjToGuid(); //模块Id
            Guid recordId = _Request.QueryEx("recordId").ObjToGuid(); //记录Id
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
            string fvStr = _Request.QueryEx("fieldValue").ObjToStr();
            string fieldValue = HttpUtility.UrlDecode(fvStr, Encoding.UTF8).Replace("%20", "+"); //字段值
            string errMsg = string.Empty;
            bool rs = CommonOperate.UpdateField(moduleId, recordId, fieldName, fieldValue, out errMsg);
            string fieldDisplayValue = string.Empty;
            if (rs) //更新成功后获取字段的显示值
            {
                fieldDisplayValue = SystemOperate.GetFieldDisplayValue(moduleId, recordId, fieldName);
            }
            //添加操作日志
            UserInfo currUser = GetCurrentUser(_Request);
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, moduleId, "更新字段值", JsonHelper.Serialize(new { recordId = recordId, fieldName = fieldName, fieldValue = fieldValue }), rs, errMsg);
            });
            //返回数据
            return Json(new UpdateFieldReturnResult() { Success = rs, Message = errMsg, FieldDisplayValue = fieldDisplayValue });
        }

        /// <summary>
        /// 批量更新字段值
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BatchUpdate()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(new ReturnResult { Success = false, Message = "模块不存在！" });
            UserInfo currUser = GetCurrentUser(_Request);
            if (currUser == null)
            {
                return Json(new ReturnResult { Success = false, Message = string.Format("您没有模块【{0}】的批量编辑权限，如有疑问请联系管理员！", module.Name) });
            }
            string ids = _Request.QueryEx("ids").ObjToStr(); //记录Id集合，以逗号分隔
            //要更新的字段数据
            string dataStr = _Request.QueryEx("data").ObjToStr();
            string formData = HttpUtility.UrlDecode(MySecurity.DecodeBase64(dataStr), Encoding.UTF8).Replace("%20", "+");
            List<NameValueObject> nvs = JsonHelper.Deserialize<List<NameValueObject>>(formData);
            if (nvs == null || nvs.Count == 0)
                return Json(new ReturnResult { Success = false, Message = "没有可更新的数据" });
            Type modelType = CommonOperate.GetModelType(module.Id); //实体类型
            //构造匿名对象
            Type t = ClassHelper.BuildType("TempClass");
            foreach (NameValueObject nv in nvs)
            {
                PropertyInfo p = modelType.GetProperty(nv.name);
                if (p == null) continue;
                //先定义两个属性。
                List<ClassHelper.CustPropertyInfo> lcpi = new List<ClassHelper.CustPropertyInfo>();
                ClassHelper.CustPropertyInfo cpi;
                cpi = new ClassHelper.CustPropertyInfo(p.PropertyType.ToString(), nv.name);
                lcpi.Add(cpi);
                //再加入上面定义的两个属性到我们生成的类t。
                t = ClassHelper.AddProperty(t, lcpi);
            }
            object o = ClassHelper.CreateInstance(t);
            foreach (NameValueObject nv in nvs)
            {
                PropertyInfo p = modelType.GetProperty(nv.name);
                if (p == null) continue;
                ClassHelper.SetPropertyValue(o, nv.name, TypeUtil.ChangeType(nv.value, p.PropertyType));
            }
            //更新字段数据
            string errMsg = string.Empty;
            object expression = null;
            if (!string.IsNullOrEmpty(ids)) //更新指定记录
            {
                Array arr = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.ObjToGuid()).ToArray();
                List<ConditionItem> conditions = new List<ConditionItem>() { new ConditionItem() { Field = "Id", Method = QueryMethod.In, Value = arr } };
                expression = CommonOperate.GetQueryCondition(module.Id, conditions);
            }
            bool rs = CommonOperate.UpdateRecordsByExpression(module.Id, o, expression, out errMsg);
            //添加操作日志
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, module.Name, "批量更新字段值", JsonHelper.Serialize(new { ids = ids, fieldObj = nvs }), rs, errMsg);
            });
            //返回数据
            return Json(new ReturnResult() { Success = rs, Message = errMsg });
        }

        /// <summary>
        /// 下载导入模板
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public ActionResult DownImportTemplate()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            //Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            ////先查找导入模板是否存在，存在则取出不存在则生成导入模板
            //string fileName = string.Format("{0}-导入模板.xls", module.Name);
            //string templateFile = _Request.RequestContext.HttpContext.Server.MapPath(string.Format("/Template/ImportModel/{0}", fileName));
            //bool noCreate = _Request.QueryEx()["nocreate"].ObjToInt() == 1 && System.IO.File.Exists(templateFile); //不创建模板
            ////生成实体导入模板
            //string errMsg = noCreate ? string.Empty : ToolOperate.CreateImportModelTemplate(module, GetCurrentUser(_Request), templateFile);
            //if (string.IsNullOrEmpty(errMsg))
            //{
            //    try
            //    {
            //        var fs = new System.IO.FileStream(templateFile, System.IO.FileMode.Open);
            //        return File(fs, "text/plain", fileName);
            //    }
            //    catch (Exception ex)
            //    {
            //        errMsg = ex.Message;
            //    }
            //}
            //return Content(string.Format("<script>alert('{0}');</script>", errMsg));
            return Content("<script>alert('111');</script>");
        }

        /// <summary>
        /// 导入实体数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult ImportModelData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(new ReturnResult() { Success = false, Message = "模块不存在！" });
            string fmStr = _Request.QueryEx("fileName").ObjToStr();
            string fileName = HttpUtility.UrlDecode(fmStr, Encoding.UTF8); //相对路径
            fileName = Globals.GetWebDir() + fileName;
            string errMsg = string.Empty;
            UserInfo currUser = GetCurrentUser(_Request);
            if (System.IO.File.Exists(fileName))
            {
                errMsg = CommonOperate.ImportData(module.Id, currUser, fileName);
                try
                {
                    //导入完成后删除临时文件
                    System.IO.File.Delete(fileName);
                }
                catch
                { }
            }
            else //文件不存在
            {
                errMsg = string.Format("文件【{0}】不存在！", _Request.QueryEx("fileName").ObjToStr());
            }
            //添加操作日志
            Task.Factory.StartNew(() =>
            {
                LogOperate.AddOperateLog(currUser, module.Name, "导入数据", string.Empty, string.IsNullOrEmpty(errMsg), errMsg);
            });
            //返回数据
            return Json(new ReturnResult() { Success = string.IsNullOrEmpty(errMsg), Message = errMsg });
        }

        #endregion

        #region 通用下拉框数据绑定

        /// <summary>
        /// 绑定枚举字段下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BindEnumFieldData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Json(null);
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
            return Json(SystemOperate.EnumFieldDataJson(module.Id, fieldName));
        }

        /// <summary>
        /// 绑定外键字段下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BindForeignFieldComboData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
            if (SystemOperate.IsForeignNameField(module.Id, fieldName))
                fieldName = fieldName.Substring(0, fieldName.Length - 4) + "Id";
            return Json(SystemOperate.ForeignFieldComboDataJson(module.Id, fieldName, GetCurrentUser(_Request)));
        }

        /// <summary>
        /// 绑定下拉框字典数据，参数为模块Id或模块名称、字段名或参数为字典分类名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BindDictionaryData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            string className = _Request.QueryEx("className").ObjToStr();
            if (string.IsNullOrEmpty(className)) //根据字段绑定取字典分类
            {
                Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
                string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
                return Json(SystemOperate.DictionaryDataJson(module.Id, fieldName));
            }
            else //根据分类名称取字典数据
            {
                return Json(SystemOperate.DictionaryDataJson(className));
            }
        }

        /// <summary>
        /// 绑定下级字典，参数为模块Id或模块名称、字段名、字典值
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BindChildDictionary()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
            string dicValue = _Request.QueryEx("dicValue").ObjToStr(); //当前字典值
            return Json(SystemOperate.GetChildDictionaryJson(module.Id, fieldName, dicValue));
        }

        /// <summary>
        /// 绑定字段已存在的值为下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BindExistsFieldValueData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名称
            string errMsg = string.Empty;
            Dictionary<string, string> dic = CommonOperate.GetColumnFieldValues(out errMsg, module.Id, fieldName);
            return Json(dic.Select(x => new { Name = x.Key, Id = x.Value }).ToList());
        }

        /// <summary>
        /// 绑定模块下拉框数据
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public JsonResult BindModuleComboData()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            GridDataParmas gridDataParams = CommonOperate.GetGridDataParams(_Request);
            gridDataParams.PagingInfo.pagesize = int.MaxValue;
            long total = 0;
            object list = CommonOperate.GetGridData(gridDataParams, out total, GetCurrentUser(_Request));
            return Json(list);
        }

        #endregion

        #region 辅助功能

        /// <summary>
        /// 自动完成功能
        /// </summary>
        /// <returns></returns>
        [OpTimeMonitor]
        public ActionResult AutoComplete()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Sys_Module module = SystemOperate.GetModuleByRequest(_Request);
            if (module == null) return Content(string.Empty);
            Guid moduleId = module.Id;
            List<string> needLoadFields = new List<string>() { "Id" }; //需要加载的字段
            string fieldName = _Request.QueryEx("fieldName").ObjToStr(); //字段名
            string otherFields = _Request.QueryEx("of").ObjToStr(); //其他需要加的字段名
            //实体类型
            Type modelType = CommonOperate.GetModelType(moduleId);
            PropertyInfo p = modelType.GetProperty(fieldName); //字段属性
            if (p == null) return Content(string.Empty);
            string template = _Request.QueryEx("template").ObjToStr().Trim(); //显示模板 
            string q = _Request.QueryEx("q").ObjToStr().Trim(); //搜索关键字
            string conditionStr = _Request.QueryEx("condition").ObjToStr();
            string condition = HttpUtility.UrlDecode(conditionStr, Encoding.UTF8); //过滤条件
            //复杂条件集合
            string cdItemTemp = _Request.QueryEx("cdItems").ObjToStr();
            string cdItemStr = HttpUtility.UrlDecode(cdItemTemp, Encoding.UTF8);
            List<ConditionItem> cdItems = new List<ConditionItem>();
            if (!string.IsNullOrEmpty(cdItemStr))
            {
                try
                {
                    cdItems = JsonHelper.Deserialize<List<ConditionItem>>(cdItemStr);
                }
                catch { }
            }
            //where条件语句，用Base64加密后传输
            string whereCon = string.Empty;
            try
            {
                string whereStr = _Request.QueryEx("where").ObjToStr();
                string tempWhere = HttpUtility.UrlDecode(whereStr, Encoding.UTF8);
                if (!string.IsNullOrWhiteSpace(tempWhere))
                {
                    whereCon = MySecurity.DecodeBase64(tempWhere);
                }
            }
            catch
            { }
            Sys_Field sysField = SystemOperate.GetFieldInfo(moduleId, fieldName); //字段信息
            string foreignModuleName = sysField != null ? sysField.ForeignModuleName : (fieldName == "CreateUserName" || fieldName == "ModifyUserName" ? "员工管理" : string.Empty);
            Sys_Module foreignModule = SystemOperate.GetModuleByName(foreignModuleName); //外键模块
            bool canAutoCompleted = p.PropertyType == typeof(String) || foreignModule != null;
            Type foreginModelType = null; //外键实体类型
            List<string> ofList = null; //其他处理字段
            //标识，autoFlag为1时取外键模块数据，新增编辑外键字段时从外键模块表中取，其他情况从当前模块中取该字段数据
            string flagStr = _Request.QueryEx("autoFlag").ObjToStr();
            bool flag = flagStr == "1" && foreignModule != null && !string.IsNullOrWhiteSpace(foreignModule.TitleKey);
            PropertyInfo idProperty = p;
            if (flag)
            {
                fieldName = foreignModule.TitleKey;
                needLoadFields.Add(fieldName);
                moduleId = foreignModule.Id;
                sysField = SystemOperate.GetFieldInfo(moduleId, fieldName); //字段信息
                foreginModelType = CommonOperate.GetModelType(foreignModule.Id);
                idProperty = foreginModelType.GetProperty("Id");
                if (!string.IsNullOrEmpty(otherFields))
                {
                    ofList = otherFields.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    ofList = ofList.Where(x => x != "Id").ToList();
                    List<string> tempOfList = SystemOperate.GetAllSysFields(x => x.Sys_ModuleId == moduleId && ofList.Contains(x.Name)).Select(x => x.Name).ToList();
                    needLoadFields.AddRange(tempOfList);
                }
            }
            else
            {
                needLoadFields.Add(fieldName);
                if (!string.IsNullOrEmpty(module.TitleKey) && !needLoadFields.Contains(module.TitleKey))
                    needLoadFields.Add(module.TitleKey);
            }
            if (canAutoCompleted) //可以调用自动完成功能取值
            {
                long total = 0;
                PageInfo pageInfo = PageInfo.GetPageInfo(_Request);
                if (!string.IsNullOrEmpty(q))
                {
                    bool isEnableCache = ModelConfigHelper.IsModelEnableCache(flag ? foreginModelType : modelType);
                    if (!isEnableCache)
                    {
                        pageInfo.sortname = isEnableCache ? string.Format("len({0}),CreateDate", fieldName) : string.Format("len({0}),AutoIncrmId", fieldName);
                        pageInfo.sortorder = "asc,desc";
                    }
                }
                AutoCompelteDataParams gridDataParams = new AutoCompelteDataParams(moduleId, fieldName, pageInfo, q, condition, cdItems, whereCon);
                object tempExp = null;
                if (!flag)
                {
                    List<ConditionItem> tempItems = new List<ConditionItem>();
                    object tempValue = null;
                    if (foreignModule != null)
                        tempValue = Guid.Empty;
                    else
                        tempValue = string.Empty;
                    tempItems.Add(new ConditionItem() { Field = fieldName, Method = QueryMethod.NotEqual, Value = tempValue });
                    tempItems.Add(new ConditionItem() { Field = fieldName, Method = QueryMethod.NotEqual, Value = null });
                    tempExp = CommonOperate.GetQueryCondition(module.Id, tempItems);
                }
                else
                {
                    gridDataParams.InitModule = module.Name;
                }
                needLoadFields = needLoadFields.Distinct().ToList();
                gridDataParams.NeedLoadFields = needLoadFields;
                object list = CommonOperate.GetGridData(gridDataParams, out total, GetCurrentUser(_Request), tempExp);
                StringBuilder sb = new StringBuilder("[");
                List<string> tempList = new List<string>();
                foreach (object obj in (list as IEnumerable))
                {
                    object tempValue = idProperty.GetValue2(obj, null);
                    if (tempValue == null) continue;
                    string displayText = string.Empty;
                    object customerResult = CommonOperate.ExecuteCustomeOperateHandleMethod(moduleId, "GetAutoCompleteDisplay", new object[] { obj, null, null, null });
                    if (customerResult != null && customerResult.ObjToStr() != string.Empty)
                        template = customerResult.ObjToStr();
                    if (!string.IsNullOrEmpty(template) && ofList != null && ofList.Count > 0)
                    {
                        displayText = template;
                        foreach (string f in ofList)
                        {
                            PropertyInfo tempP = foreginModelType.GetProperty(f);
                            if (tempP == null) continue;
                            Sys_Field tempSysField = SystemOperate.GetFieldInfo(moduleId, f); //字段信息
                            Sys_FormField tempFormField = SystemOperate.GetNfDefaultFormSingleField(tempSysField);
                            string replaceStr = SystemOperate.GetFieldDisplayValue(moduleId, obj, tempSysField, tempFormField);
                            displayText = displayText.Replace("{" + f + "}", replaceStr);
                        }
                    }
                    else
                    {
                        //表单字段
                        Sys_FormField formField = SystemOperate.GetNfDefaultFormSingleField(sysField);
                        displayText = SystemOperate.GetFieldDisplayValue(moduleId, obj, sysField, formField);
                    }
                    if (string.IsNullOrEmpty(displayText)) continue;
                    if (ofList != null && ofList.Count > 0) //需要加载其他字段值
                    {
                        string tempDisplayText = displayText;
                        if (!string.IsNullOrEmpty(template)) //指定模板
                        {
                            Sys_FormField formField = SystemOperate.GetNfDefaultFormSingleField(sysField);
                            tempDisplayText = SystemOperate.GetFieldDisplayValue(moduleId, obj, sysField, formField);
                        }
                        else if (SystemOperate.GetModuleTableNameById(moduleId) == "OrgM_Emp") //员工
                        {
                            OrgM_Emp emp = obj as OrgM_Emp;
                            if (emp != null)
                                displayText = string.Format("{0}（{1}，{2}）", displayText, emp.Code.ObjToStr(), OrgMOperate.GetEmpMainDeptName(emp.Id));
                        }
                        string tempStr = "{";
                        tempStr += string.Format("\"Id\":\"{0}\"", tempValue.ObjToStr());
                        tempStr += string.Format(",\"Name\":\"{0}\"", displayText);
                        foreach (string f in ofList)
                        {
                            if (f == "Name" || f == "f_Name") //f_Name是text，Name是模板显示
                                continue;
                            PropertyInfo tempP = foreginModelType.GetProperty(f);
                            if (tempP == null) continue;
                            string fValue = tempP.GetValue2(obj, null).ObjToStr();
                            tempStr += string.Format(",\"{0}\":\"{1}\"", f, fValue);
                            if (SystemOperate.IsEnumField(moduleId, f)) //枚举字段
                            {
                                string enumDisplay = SystemOperate.GetEnumFieldDisplayText(moduleId, f, fValue);
                                tempStr += string.Format(",\"{0}_Enum\":\"{1}\"", f, enumDisplay);
                            }
                            else if (SystemOperate.IsDictionaryBindField(moduleId, f)) //字典绑定字段
                            {
                                string dicDisplay = SystemOperate.GetDictionaryDisplayText(moduleId, f, fValue);
                                tempStr += string.Format(",\"{0}_Dic\":\"{1}\"", f, dicDisplay);
                            }
                            else if (SystemOperate.IsForeignField(moduleId, f)) //外键字段
                            {
                                Sys_Module tempForeignModule = SystemOperate.GetForeignModule(moduleId, f);
                                if (tempForeignModule != null)
                                {
                                    string foreignDisplay = CommonOperate.GetModelTitleKeyValue(tempForeignModule.Id, fValue.ObjToGuid());
                                    tempStr += string.Format(",\"{0}\":\"{1}\"", f.Substring(0, f.Length - 2) + "Name", foreignDisplay);
                                }
                            }
                        }
                        tempStr += string.Format(",\"f_Name\":\"{0}\"", tempDisplayText);
                        tempStr += "},";
                        if (tempList.Contains(tempStr))
                            continue;
                        tempList.Add(tempStr);
                        sb.Append(tempStr);
                    }
                    else
                    {
                        if (tempList.Contains(displayText))
                            continue;
                        string tempDisplayText = displayText;
                        tempList.Add(tempDisplayText);
                        if (SystemOperate.GetModuleTableNameById(moduleId) == "OrgM_Emp") //员工
                        {
                            OrgM_Emp emp = obj as OrgM_Emp;
                            if (emp != null)
                                displayText = string.Format("{0}（{1}，{2}）", displayText, emp.Code.ObjToStr(), OrgMOperate.GetEmpMainDeptName(emp.Id));
                        }
                        sb.Append("{\"Name\":\"" + displayText + "\",\"f_Name\":\"" + tempDisplayText + "\",\"Id\":\"" + tempValue.ObjToStr() + "\"},");
                    }
                }
                string json = string.Empty;
                if (sb.ToString().Length > 1)
                {
                    json = sb.ToString().Substring(0, sb.ToString().Length - 1); //去掉最后一个逗号
                    json += "]";
                }
                return Content(json);
            }
            return Content(string.Empty);
        }

        #endregion
    }

    /// <summary>
    /// 公共通用数据控制器（API）
    /// </summary>
    [Route("api/[controller]/[action].html")]
    public class DataApiController : BaseApiController
    {
        #region 通用树

        /// <summary>
        /// 加载树（结点方式）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult GetTreeByNode()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.GetTreeByNode() as JsonResult;
            return result;
        }

        #endregion

        #region 通用列表

        /// <summary>
        /// 通用分页数据加载
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult LoadGridData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.LoadGridData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 导出模块数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult ExportModelData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.ExportModelData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 列表工具栏操作验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult GridOperateVerify()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.GridOperateVerify() as JsonResult;
            return result;
        }

        #endregion

        #region 通用保存

        /// <summary>
        /// 通用保存数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult SaveData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.SaveData() as JsonResult;
            return result;
        }

        #endregion

        #region 通用删除

        /// <summary>
        /// 通用删除，单条记录，多条记录删除均适用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult Delete()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.Delete() as JsonResult;
            return result;
        }

        /// <summary>
        /// 通用还原，单条记录，多条记录删除均适用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult Restore()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.Restore() as JsonResult;
            return result;
        }

        #endregion

        #region 表单处理

        /// <summary>
        /// 表单数据加载
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult LoadFormData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.LoadFormData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 加载模块数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult LoadModuleDatas()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.LoadModuleDatas() as JsonResult;
            return result;
        }

        /// <summary>
        /// 更新字段值
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult UpdateField()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.UpdateField() as JsonResult;
            return result;
        }

        /// <summary>
        /// 批量更新字段值
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BatchUpdate()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BatchUpdate() as JsonResult;
            return result;
        }

        /// <summary>
        /// 下载导入模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult DownImportTemplate()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.DownImportTemplate() as JsonResult;
            return result;
        }

        /// <summary>
        /// 导入实体数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult ImportModelData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.ImportModelData() as JsonResult;
            return result;
        }

        #endregion

        #region 通用下拉框数据绑定

        /// <summary>
        /// 绑定枚举字段下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BindEnumFieldData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BindEnumFieldData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 绑定外键字段下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BindForeignFieldComboData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BindForeignFieldComboData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 绑定下拉框字典数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BindDictionaryData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BindDictionaryData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 绑定下级字典数据，参数为模块Id或模块名称、字段名、字典值
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BindChildDictionary()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BindChildDictionary() as JsonResult;
            return result;
        }

        /// <summary>
        /// 绑定字段已存在的值为下拉框数据，参数为模块Id或模块名称、字段名
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BindExistsFieldValueData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BindExistsFieldValueData() as JsonResult;
            return result;
        }

        /// <summary>
        /// 绑定模块下拉框数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult BindModuleComboData()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.BindModuleComboData() as JsonResult;
            return result;
        }

        #endregion

        #region 辅助功能

        /// <summary>
        /// 自动完成功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult AutoComplete()
        {
            DataController c = new DataController();
            c.RequestSet = Request;
            JsonResult result = c.AutoComplete() as JsonResult;
            return result;
        }

        #endregion
    }
}
