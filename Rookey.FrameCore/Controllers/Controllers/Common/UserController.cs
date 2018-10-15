/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Rookey.Frame.Base;
using Rookey.Frame.Base.Set;
using Rookey.Frame.Common;
using Rookey.Frame.Controllers.Attr;
using Rookey.Frame.Controllers.Other;
using Rookey.Frame.Model.OrgM;
using Rookey.Frame.Model.Sys;
using Rookey.Frame.Operate.Base;
using Rookey.Frame.Operate.Base.Extension;
using Rookey.Frame.Operate.Base.TempModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rookey.Frame.Controllers
{
    /// <summary>
    /// 用户控制器（异步）
    /// </summary>
    public class UserAsyncController : BaseController
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <param name="valcode">验证码</param>
        /// <returns></returns>
        [Login]
        [Anonymous]
        public Task<JsonResult> UserLogin(string username, string userpwd, string valcode)
        {
            return Task.Factory.StartNew(() =>
            {
                UserController uc = new UserController();
                uc.RequestSet = Request;
                uc.ResponseSet = Response;
                uc.TempDataSet = TempData;
                return uc.UserLogin(username, userpwd, valcode);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 获取数据权限组织树
        /// </summary>
        /// <returns></returns>
        public Task<JsonResult> GetDataPermissionOrgTree()
        {
            return Task.Factory.StartNew(() =>
            {
                UserController uc = new UserController();
                uc.RequestSet = Request;
                return uc.GetDataPermissionOrgTree();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public Task<JsonResult> ChangePwd()
        {
            return Task.Factory.StartNew(() =>
            {
                UserController uc = new UserController();
                uc.RequestSet = Request;
                return uc.ChangePwd();
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }
    }

    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : BaseController
    {
        #region 构造函数

        private HttpRequest _Request = null; //请求对象
        private HttpResponse _Response = null; //响应对象
        private ITempDataDictionary _TempData = null; //临时字典对象

        public HttpRequest RequestSet { set { _Request = value; } }
        public HttpResponse ResponseSet { set { _Response = value; } }
        public ITempDataDictionary TempDataSet { set { _TempData = value; } }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public UserController()
        {
            _Request = Request;
            _Response = Response;
            _TempData = TempData;
        }

        #endregion

        #region 公共方法

        #region 页面
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public ActionResult Login()
        {
            if (!ToolOperate.IsNeedInit()) //不需要初始化时
            {
                if (WebConfigHelper.GetAppSettingValue("NeedRepairTable") == "true") //需要修复数据表
                {
                    string tables = WebConfigHelper.GetAppSettingValue("RepairTables"); //要修复的数据表
                    List<string> token = new List<string>();
                    if (!string.IsNullOrEmpty(tables))
                    {
                        token = tables.Split(",".ToCharArray()).ToList();
                    }
                    if (token.Count > 0)
                    {
                        ToolOperate.RepairTables(token);
                    }
                }
            }
            else //需要初始化
            {
                return RedirectToAction("Init", "Page");
            }
            return View();
        }

        /// <summary>
        /// 弹出登录框
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public ActionResult DialogLogin()
        {
            return View();
        }

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public ActionResult Reg()
        {
            return View();
        }

        /// <summary>
        /// 忘记密码页面
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public ActionResult ForgetPwd()
        {
            return View();
        }

        /// <summary>
        /// 重置密码页面
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public ActionResult ResetPwd()
        {
            Guid uid = _Request.QueryEx("uid").ObjToGuid();
            if (uid == Guid.Empty || string.IsNullOrEmpty(UserOperate.GetUserNameByUserId(uid)))
                return RedirectToAction("ForgetPwd");
            return View();
        }
        #endregion

        #region 操作
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <param name="valcode">验证码</param>
        /// <returns></returns>
        [Login]
        [Anonymous]
        public JsonResult UserLogin(string username, string userpwd, string valcode)
        {
            if (string.IsNullOrEmpty(username))
            {
                return Json(new LoginReturnResult() { Success = false, Message = "用户名不能为空", IsShowCode = false });
            }
            if (_Request == null) _Request = Request;
            if (_Response == null) _Response = Response;
            string errMsg = string.Empty;
            //获取用户信息
            string tempUserName = GetUserName(username);
            UserInfo userInfo = UserOperate.GetUserInfo(tempUserName, userpwd, out errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return Json(new LoginReturnResult() { Success = false, Message = errMsg, IsShowCode = false });
            }
            CacheUserData(userInfo); //缓存cookie
            //执行登录成功后的操作
            CommonOperate.ExecuteUserOperateHandleMethod("AfterLoginSuccess", new object[] { _Request, _Response, username, userpwd, UserInfo.ACCOUNT_EXPIRATION_TIME });

            return Json(new LoginReturnResult() { Success = true, Message = string.Empty, Url = string.Empty });
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="username">用户名或工号或邮箱或手机号</param>
        /// <returns></returns>
        private string GetUserName(string username)
        {
            string tempUserName = username.Trim();
            string errMsg = string.Empty;
            if (GlobalSet.IsAllowOtherConfigRuleLogin) //允许其他方式登录
            {
                //先检测默认登录规则账号是否存在
                bool rs = UserOperate.UserIsValid(tempUserName, out errMsg);
                if (rs)
                    return tempUserName;
                //默认登录规则账号不存在时检测其他方式
                OrgM_Emp emp = null;
                switch (GlobalSet.EmpUserNameConfigRule)
                {
                    case UserNameAndEmpConfigRule.EmpCode:
                        {
                            emp = OrgMOperate.GetEmpByMobile(tempUserName); //根据手机号获取员工
                            if (emp == null)
                            {
                                emp = OrgMOperate.GetEmpByEmail(tempUserName); //根据邮箱获取员工
                                if (emp == null)
                                    emp = OrgMOperate.GetEmpByEmailPrex(tempUserName); //根据邮箱前缀获取员工
                            }
                        }
                        break;
                    case UserNameAndEmpConfigRule.Mobile:
                        {
                            emp = OrgMOperate.GetEmpByCode(tempUserName); //根据工号获取员工
                            if (emp == null)
                            {
                                emp = OrgMOperate.GetEmpByEmail(tempUserName); //根据邮箱获取员工
                                if (emp == null)
                                    emp = OrgMOperate.GetEmpByEmailPrex(tempUserName); //根据邮箱前缀获取员工
                            }
                        }
                        break;
                    case UserNameAndEmpConfigRule.Email:
                        {
                            emp = OrgMOperate.GetEmpByCode(tempUserName); //根据工号获取员工
                            if (emp == null)
                            {
                                emp = OrgMOperate.GetEmpByMobile(tempUserName); //根据手机号获取员工
                                if (emp == null)
                                    emp = OrgMOperate.GetEmpByEmailPrex(tempUserName); //根据邮箱前缀获取员工
                            }
                        }
                        break;
                    case UserNameAndEmpConfigRule.EmailPre:
                        {
                            emp = OrgMOperate.GetEmpByCode(tempUserName); //根据工号获取员工
                            if (emp == null)
                            {
                                emp = OrgMOperate.GetEmpByMobile(tempUserName); //根据手机号获取员工
                                if (emp == null)
                                    emp = OrgMOperate.GetEmpByEmail(tempUserName); //根据邮箱获取员工
                            }
                        }
                        break;
                }
                if (emp != null)
                    return OrgMOperate.GetUserNameByEmp(emp);
            }
            return tempUserName;
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        /// <returns></returns>
        public JsonResult ChangeUser()
        {
            if (_Request == null) _Request = Request;
            if (_Response == null) _Response = Response;
            SetRequest(_Request);
            UserInfo currUser = GetCurrentUser(_Request);
            if (currUser == null)
                return Json(new ReturnResult() { Success = false, Message = "非法操作" });
            string username = _Request.QueryEx("username").ObjToStr();
            if (username == "admin")
                return Json(new ReturnResult() { Success = false, Message = "没有权限" });
            Guid userId = UserOperate.GetUserIdByUserName(username);
            UserInfo userInfo = UserOperate.GetUserInfo(userId);
            if (userInfo == null)
                return Json(new ReturnResult() { Success = false, Message = "用户不存在" });
            userInfo.ClientBrowserWidth = currUser.ClientBrowserWidth;
            userInfo.ClientBrowserHeight = currUser.ClientBrowserHeight;
            CacheUserData(userInfo); //缓存cookie
            return Json(new ReturnResult() { Success = true, Message = string.Empty });
        }

        /// <summary>
        /// 缓存用户Cookie数据
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        private void CacheUserData(UserInfo userInfo)
        {
            //客户端浏览器参数
            int w = _Request.QueryEx("w").ObjToInt();
            int h = _Request.QueryEx("h").ObjToInt();
            if (w > 0)
                userInfo.ClientBrowserWidth = w;
            if (h > 0)
                userInfo.ClientBrowserHeight = h;
            //获取客户端IP
            userInfo.ClientIP = WebHelper.GetClientIP(_Request);
            //缓存用户扩展信息
            UserInfo.CacheUserExtendInfo(userInfo.UserName, userInfo.ExtendUserObject);
            //用户票据保存
            FormsPrincipal.Login(userInfo.UserName, userInfo, UserInfo.ACCOUNT_EXPIRATION_TIME, GetHttpContext(_Request));
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsPrincipal.Logout(GetHttpContext(_Request));
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 获取数据权限组织树
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDataPermissionOrgTree()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            string asyncStr = _Request.QueryEx("async").ObjToStr();
            bool isAsync = asyncStr.ObjToInt() == 1; //是否异步
            string idStr = _Request.QueryEx("id").ObjToStr();
            Guid? tempId = idStr.ObjToGuidNull();
            TreeNode tempNode = new TreeNode() { id = "-1", text = "全部", iconCls = "eu-icon-dept" };
            TreeNode currDeptNode = new TreeNode() { id = "0", text = "本部门", iconCls = "eu-icon-dept" };
            Expression<Func<Sys_Organization, bool>> expression = null;
            string q = _Request.QueryEx("q").ObjToStr(); //查询字符
            if (!string.IsNullOrEmpty(q))
                expression = x => x.Name.Contains(q);
            TreeNode node = CommonOperate.GetTreeNode<Sys_Organization>(tempId, null, null, null, null, "eu-icon-dept", expression, null, null, isAsync, GetCurrentUser(_Request));
            if (isAsync)
            {
                node.state = "closed";
                if (node.children != null && node.children.Count() > 0)
                {
                    node.children.ForEach(x => { x.state = "closed"; });
                }
            }
            if (tempId == null || tempId == Guid.Empty)
            {
                List<TreeNode> list = new List<TreeNode> { tempNode, currDeptNode };
                if (node != null) list.Add(node);
                return Json(list.ToJson().Content);
            }
            else
            {
                return Json(node.children.ToJson().Content);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public JsonResult ChangePwd()
        {
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            UserInfo currUser = GetCurrentUser(_Request);
            if (currUser == null)
            {
                return Json(new ReturnResult() { Success = false, Message = "您未登录系统或登录时间过长，请重新登录系统后再修改密码！" });
            }
            string errMsg = string.Empty;
            string oldPwd = _Request.QueryEx("oldPwd").ObjToStr();
            string newPwd = _Request.QueryEx("newPwd").ObjToStr();
            UserInfo tempUserInfo = UserOperate.GetUserInfo(currUser.UserName, oldPwd, out errMsg);
            if (tempUserInfo == null)
            {
                return Json(new ReturnResult() { Success = false, Message = "您当前登录密码输入不正确，请重新输入！" });
            }
            bool rs = UserOperate.ModifyPassword(currUser.UserId, newPwd, out errMsg);
            if (rs)
            {
                CommonOperate.ExecuteUserOperateHandleMethod("AfterChangePwd", new object[] { currUser.UserName, oldPwd, newPwd });
            }
            return Json(new ReturnResult() { Success = rs, Message = errMsg });
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <param name="useralias">用户别名</param>
        /// <returns></returns>
        [Anonymous]
        public JsonResult UserReg(string username, string userpwd, string useralias)
        {
            string userTipDes = "用户名";
            if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Email)
                userTipDes = "邮箱";
            else if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Mobile)
                userTipDes = "手机号";
            if (string.IsNullOrEmpty(username))
                return Json(new ReturnResult() { Success = false, Message = string.Format("{0}不能为空！", userTipDes) });
            if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Email && !Validator.IsEmail(username))
                return Json(new ReturnResult() { Success = false, Message = "请输入正确的邮箱地址！" });
            if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Mobile && !Validator.IsMobilePhoneNumber(username))
                return Json(new ReturnResult() { Success = false, Message = "请输入正确的手机号码！" });
            if (string.IsNullOrEmpty(userpwd))
                return Json(new ReturnResult() { Success = false, Message = "密码不能为空！" });
            if (!string.IsNullOrEmpty(useralias) && useralias.Length > 15)
                return Json(new ReturnResult() { Success = false, Message = "用户别称不能超过15位！" });
            string errMsg = string.Empty;
            Guid userId = UserOperate.AddUser(out errMsg, username, userpwd, null, useralias);
            return Json(new ReturnResult() { Success = string.IsNullOrEmpty(errMsg), Message = errMsg });
        }

        /// <summary>
        /// 忘记密码，忘记密码给用户发送邮件将修改密码链接发送给用户
        /// 用户点击链接进行密码修改
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [Anonymous]
        public JsonResult UserForgetPwd(string username)
        {
            string userTipDes = "用户名";
            if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Email)
                userTipDes = "邮箱";
            else if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Mobile)
                userTipDes = "手机号";
            if (string.IsNullOrEmpty(username))
                return Json(new ReturnResult() { Success = false, Message = string.Format("{0}不能为空！", userTipDes) });
            if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Email && !Validator.IsEmail(username))
                return Json(new ReturnResult() { Success = false, Message = "请输入正确的邮箱地址！" });
            if (GlobalSet.EmpUserNameConfigRule == UserNameAndEmpConfigRule.Mobile && !Validator.IsMobilePhoneNumber(username))
                return Json(new ReturnResult() { Success = false, Message = "请输入正确的手机号码！" });
            string errMsg = string.Empty;
            bool rs = UserOperate.UserIsValid(username, out errMsg);
            if (!rs)
                return Json(new ReturnResult() { Success = false, Message = errMsg });
            string email = username;
            if (GlobalSet.EmpUserNameConfigRule != UserNameAndEmpConfigRule.Email)
            {
                OrgM_Emp emp = OrgMOperate.GetEmpByUserName(username);
                if (emp != null)
                {
                    email = OrgMOperate.GetEmployeeEmails(new List<Guid>() { emp.Id }).Keys.FirstOrDefault();
                }
            }
            if (!email.Contains("@"))
                return Json(new ReturnResult() { Success = false, Message = "获取用户邮箱失败！" });
            Dictionary<string, string> dicMail = new Dictionary<string, string>();
            dicMail.Add(email, email);
            string subject = string.Format("重置您在{0}的密码", WebConfigHelper.GetCurrWebName());
            Sys_User user = UserOperate.GetUser(username);
            string content = GetForgetPwdSendContent(user);
            errMsg = SystemOperate.EmailSend(subject, content, dicMail, null, null, null, true, "dingxin.wang@cecport.com", null, "wdx840324");
            return Json(new ReturnResult() { Success = string.IsNullOrEmpty(errMsg), Message = errMsg });
        }

        /// <summary>
        /// 获取重置密码邮件内容
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        private string GetForgetPwdSendContent(Sys_User user)
        {
            StringBuilder sb = new StringBuilder();
            string webServer = WebConfigHelper.GetAppSettingValue("WebServer"); //跳转服务器
            string webIndex = WebConfigHelper.GetAppSettingValue("WebIndex"); //跳转首页地址
            string webName = WebConfigHelper.GetCurrWebName();
            sb.Append("<div style=\"font-size: 13px;padding:40px;background-color: #F7F7F7;font-family:Arial, Helvetica, sans-serif; color:#333;\">");
            sb.Append("<div class=\"mailcontentbox\" style=\"min-width: 500px;max-width: 750px;\">");
            sb.Append("<div style=\"background-color: gray;\">");
            sb.AppendFormat("<a href=\"{0}{1}\" target=\"_blank\">", webServer, webIndex);
            string logoPath = WebConfigHelper.GetCurrWebLogo();
            if (!string.IsNullOrEmpty(logoPath))
            {
                logoPath = logoPath.Substring(1, logoPath.Length - 1);
                logoPath = webServer + logoPath;
            }
            sb.AppendFormat("<img style=\"margin:5px 0px 5px 10px;\" src=\"{0}\" border=\"0\">", logoPath);
            sb.Append("</a>");
            sb.Append("</div>");
            sb.Append("<div style=\"border-width:0px 1px 2px 1px;border-style:solid;border-color:#D7D7D7;border-bottom-color:#333;padding:20px;background:#fff;\">");
            sb.Append("<p style=\"line-height:20px;padding-bottom:5px;\">");
            sb.AppendFormat("	您好 {0},", string.IsNullOrEmpty(user.AliasName) ? user.UserName : user.AliasName);
            sb.Append("</p>");
            sb.Append("<p style=\"line-height:20px;padding-bottom:5px;\">");
            sb.AppendFormat("您发送了重置{0}密码的申请。			</p>", webName);
            sb.Append("<p style=\"line-height:20px;padding-bottom:5px;\">");
            sb.Append("请点击下边的链接进行确认，之后您将可以设置一个新密码。			</p>");
            sb.Append("<p style=\"line-height:20px;padding-bottom:5px;\">");
            string resetPwdUrl = string.Format("{0}User/ResetPwd.html?uid={1}", webServer, user.Id);
            sb.AppendFormat("	<a href=\"{0}\" target=\"_blank\" style=\"color:#36C;\">{0}</a>", resetPwdUrl);
            sb.Append("</p>");
            sb.Append("<p style=\"line-height:13px; margin: 40px 0px 10px\">");
            sb.AppendFormat("感谢您使用{0}			</p>", webName);
            sb.Append("<p style=\"padding-bottom:5px; padding-top:0px; margin-top:0px\">");
            sb.AppendFormat("	{0} Team", webName);
            sb.Append("</p>");
            sb.Append("</div>");
            sb.Append("<div style=\"color:#777;padding: 15px;\">");
            sb.AppendFormat("	©{0} {1} Team.", DateTime.Now.Year, webName);
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }

        /// <summary>
        /// 未登录修改密码
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public JsonResult ChangePwdNoLogin()
        {
            if (_Request == null) _Request = Request;
            Guid uid = _Request.QueryEx("uid").ObjToGuid();
            if (uid == Guid.Empty || string.IsNullOrEmpty(UserOperate.GetUserNameByUserId(uid)))
                return Json(new ReturnResult() { Success = false, Message = "用户ID不存在！" });
            string pwd1 = _Request.QueryEx("pwd1").ObjToStr();
            string pwd2 = _Request.QueryEx("pwd2").ObjToStr();
            if (string.IsNullOrEmpty(pwd1.Trim()))
                return Json(new ReturnResult() { Success = false, Message = "新密码不能为空！" });
            if (pwd1.Length < 5 || pwd1.Length > 20)
                return Json(new ReturnResult() { Success = false, Message = "密码长度为5-20个字符！" });
            if (pwd1 != pwd2)
                return Json(new ReturnResult() { Success = false, Message = "两次密码输入不一致！" });
            string errMsg = string.Empty;
            bool rs = UserOperate.ModifyPassword(uid, pwd1, out errMsg);
            return Json(new ReturnResult() { Success = rs, Message = errMsg });
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 用户API控制器
    /// </summary>
    [Route("api/[controller]/[action].html")]
    public class UserApiController : BaseController
    {
        #region 公共方法

        /// <summary>
        /// 获取数据权限组织树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public dynamic GetDataPermissionOrgTree()
        {
            UserController uc = new UserController();
            uc.RequestSet = Request;
            JsonResult result = uc.GetDataPermissionOrgTree() as JsonResult;
            return result.Value;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public ReturnResult ChangePwd()
        {
            UserController uc = new UserController();
            uc.RequestSet = Request;
            JsonResult result = uc.ChangePwd() as JsonResult;
            return result.Value as ReturnResult;
        }

        #endregion
    }
}
