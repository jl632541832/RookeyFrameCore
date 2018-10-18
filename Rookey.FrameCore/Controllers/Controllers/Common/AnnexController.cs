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
using Rookey.Frame.Controllers.Other;
using Rookey.Frame.Model.Sys;
using Rookey.Frame.Operate.Base;
using Rookey.Frame.Operate.Base.OperateHandle;
using Rookey.Frame.Operate.Base.TempModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rookey.Frame.Controllers
{
    /// <summary>
    /// 通用附件控制器（异步）
    /// </summary>
    public class AnnexAsyncController : BaseController
    {
        #region UEditor上传

        /// <summary>
        /// 异步UEditor上传图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<ActionResult> ImageUp()
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.ImageUp();
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        ///  异步UEditor上传图片
        /// </summary>
        /// <param name="upfile">文件</param>
        /// <param name="pictitle">图片标题</param>
        /// <param name="dir">路径</param>
        /// <returns></returns>
        [HttpPost]
        public Task<JsonResult> ImageUp(IFormFile upfile, string pictitle, string dir)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.ImageUp(upfile, pictitle, dir);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        ///  异步UEditor上传文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<ActionResult> FileUp()
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.FileUp();
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        ///  异步UEditor上传文件
        /// </summary>
        /// <param name="upfile">文件</param>
        /// <returns></returns>
        [HttpPost]
        public Task<JsonResult> FileUp(IFormFile upfile)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.FileUp(upfile);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        ///  异步UEditor获取video
        /// </summary>
        /// <param name="searchKey">搜索关键字</param>
        /// <param name="videoType">视频类型</param>
        /// <returns></returns>
        public Task<ActionResult> GetMovie(string searchKey, string videoType)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.GetMovie(searchKey, videoType);
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步图片在线管理
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult> ImageManager(string action)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.ImageManager(action);
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步涂鸦
        /// </summary>
        /// <param name="upfile">图片文件</param>
        /// <param name="content">涂鸦内容</param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult> ScrawlUp(IFormFile upfile, string content)
        {
            return Task.Factory.StartNew(() =>
             {
                 AnnexController c = new AnnexController();
                 c.RequestSet = Request;
                 return c.ScrawlUp(upfile, content);
             }).ContinueWith<ActionResult>(task =>
             {
                 return task.Result;
             });
        }
        #endregion

        #region 表单或文档附件处理

        /// <summary>
        /// 异步上传附件，兼容非表单附件
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        [HttpPost]
        public Task<JsonResult> UploadAttachment(IFormFileCollection file)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.UploadAttachment(file);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步保存表单附件
        /// </summary>
        /// <param name="moduleId">模块Id</param>
        /// <param name="id">记录Id</param>
        /// <param name="fileMsg">文件信息</param>
        /// <param name="isAdd">是否只是添加</param>
        /// <returns></returns>
        public Task<JsonResult> SaveFormAttach(Guid moduleId, Guid id, string fileMsg, bool isAdd = false)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.SaveFormAttach(moduleId, id, fileMsg, isAdd);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步删除附件
        /// </summary>
        /// <param name="attachIds">附件Id集合，多个以逗号分隔</param>
        /// <returns></returns>
        public Task<JsonResult> DeleteAttachment(string attachIds)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.DeleteAttachment(attachIds);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步下载附件
        /// </summary>
        /// <param name="attachId">附件Id</param>
        /// <returns></returns>
        public Task<ActionResult> DownloadAttachment(Guid attachId)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.DownloadAttachment(attachId);
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        /// <summary>
        /// 异步下载文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<ActionResult> DownloadFile(string fileName)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.DownloadFile(fileName);
            }).ContinueWith<ActionResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 图片控件临时上传

        /// <summary>
        /// 异步上传临时图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<JsonResult> UploadTempImage(IFormFile file)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.UploadTempImage(file);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion

        #region 数据导入临时文件上传

        /// <summary>
        /// 异步上传临时导入模板文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<JsonResult> UploadTempImportFile(IFormFile file)
        {
            return Task.Factory.StartNew(() =>
            {
                AnnexController c = new AnnexController();
                c.RequestSet = Request;
                return c.UploadTempImportFile(file);
            }).ContinueWith<JsonResult>(task =>
            {
                return task.Result;
            });
        }

        #endregion
    }

    /// <summary>
    /// 通用附件控制器
    /// </summary>
    public class AnnexController : BaseController
    {
        #region 构造函数

        private HttpRequest _Request = null; //请求对象
        public HttpRequest RequestSet { set { _Request = value; } }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public AnnexController()
        {
            _Request = Request;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取文件路径,如果路径不存在就创建
        /// </summary>
        /// <param name="pdfSavePath"></param>
        /// <param name="swfSavePath"></param>
        private void GetFilePath(out string pdfSavePath, out string swfSavePath)
        {
            //yyyyMM
            string dateFolder = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);

            //pdf保存文件夹路径
            string pdfTempFolder = "~/Upload/PdfFile/";
            //pdf GUID
            string pdfGid = Guid.NewGuid().ToString("N");
            //生成pdf文件名
            string pdfName = pdfGid + ".pdf";
            //生成pdf相对路径
            string pdfTempPath = pdfTempFolder + pdfName;

            pdfSavePath = pdfTempPath;

            //swf GUID
            string swfGuid = Guid.NewGuid().ToString("N");
            //swf保存文件夹路径
            string swfFolder = "~/Upload/SwfFile/" + dateFolder + "/";
            //文件名
            string swfName = swfGuid + ".swf";
            //swf保存相对路径
            string swfPath = swfFolder + swfName;

            swfSavePath = swfPath;

            //保存路径
            if (!Directory.Exists(WebHelper.MapPath(pdfTempFolder)))
            {
                string tempPath = WebHelper.MapPath(pdfTempFolder);
                Directory.CreateDirectory(tempPath);
            }
            if (!Directory.Exists(WebHelper.MapPath(swfFolder)))
            {
                string strpath = WebHelper.MapPath(swfFolder);
                Directory.CreateDirectory(strpath);
            }
        }

        /// <summary>
        /// 生成SWF文件
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="isAsync">是否异步方式</param>
        /// <returns></returns>
        private bool CreateSwfFile(object obj, bool isAsync = true)
        {
            Func<bool> action = () =>
            {
                bool flag = false;
                try
                {
                    string[] aa = obj as string[];
                    string ext = aa[0];
                    string sourcePath = aa[1];
                    string pdfSavePath = aa[2];
                    string swfSavePath = aa[3];
                    string exePath = aa[4];
                    string binPath = aa[5];
                    if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        if (OfficeToPdfHelper.Doc2Pdf(sourcePath, pdfSavePath))
                        {
                            flag = SwfToolHelper.PDF2SWF(pdfSavePath, swfSavePath, exePath, binPath);
                        }
                    }
                    else if (ext.Equals(".xls") || ext.Equals(".xlsx"))
                    {
                        if (OfficeToPdfHelper.Xls2Pdf(sourcePath, pdfSavePath))
                        {
                            flag = SwfToolHelper.PDF2SWF(pdfSavePath, swfSavePath, exePath, binPath);
                        }
                    }
                    else if (ext.Equals(".ppt"))
                    {
                        if (OfficeToPdfHelper.PPt2Pdf(sourcePath, pdfSavePath))
                        {
                            flag = SwfToolHelper.PDF2SWF(pdfSavePath, swfSavePath, exePath, binPath);
                        }
                    }
                    else if (ext.Equals(".pdf"))
                    {
                        flag = SwfToolHelper.PDF2SWF(sourcePath, swfSavePath, exePath, binPath);
                    }
                }
                catch { }
                return flag;
            };
            if (isAsync) //异步方式
            {
                Task.Factory.StartNew(() =>
                {
                    action();
                });
                return true;
            }
            else //同步方式
            {
                return action();
            }
        }
        #endregion

        #region UEditor上传

        /// <summary>
        /// UEditor上传图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ImageUp()
        {
            if (_Request == null) _Request = Request;
            string result = string.Format(String.Format("updateSavePath([{0}]);", "'Image'"));
            return Content(result);
        }

        /// <summary>
        ///  UEditor上传图片
        /// </summary>
        /// <param name="upfile">文件</param>
        /// <param name="pictitle">图片标题</param>
        /// <param name="dir">路径</param>
        /// <returns></returns>
        public JsonResult ImageUp(IFormFile upfile, string pictitle, string dir)
        {
            if (_Request == null) _Request = Request;
            string path = string.Empty;
            string fileName = upfile.FileName;
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            int s = fileName.LastIndexOf(pathFlag);
            if (s >= 0)
            {
                fileName = fileName.Substring(s + 1);
            }
            try
            {
                path = UploadFile(upfile, "UEImage", dir);
            }
            catch (Exception ex)
            {
                return Json(new { state = ex.Message });
            }
            return Json(new { state = "SUCCESS", url = path, title = pictitle, original = fileName });
        }

        /// <summary>
        ///  UEditor上传文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FileUp()
        {
            if (_Request == null) _Request = Request;
            string result = string.Format(String.Format("updateSavePath([{0}]);", "'File'"));
            return Content(result);
        }

        /// <summary>
        ///  UEditor上传文件
        /// </summary>
        /// <param name="upfile">文件</param>
        /// <returns></returns>
        public JsonResult FileUp(IFormFile upfile)
        {
            if (_Request == null) _Request = Request;
            string path = string.Empty;
            string fileName = upfile.FileName;
            string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
            int s = fileName.LastIndexOf(pathFlag);
            if (s >= 0)
            {
                fileName = fileName.Substring(s + 1);
            }
            string fileType = Path.GetExtension(upfile.FileName);
            try
            {
                path = UploadFile(upfile, "UEFile", "File");
            }
            catch (Exception ex)
            {
                return Json(new { state = ex.Message });
            }
            return Json(new { state = "SUCCESS", url = path, fileType = fileType, original = fileName });
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="upfile">上传的文件</param>
        /// <param name="configName">配置名称</param>
        /// <param name="dir">保存的文件夹</param>
        /// <returns>保存路径</returns>
        private string UploadFile(IFormFile upfile, string configName, string dir)
        {
            if (_Request == null) _Request = Request;
            string filePath = string.IsNullOrWhiteSpace(dir) ? "Other" : dir;
            string path = UploadFileManager.SaveAs(upfile, configName, filePath);
            return path;
        }

        /// <summary>
        ///  UEditor获取video
        /// </summary>
        /// <param name="searchKey">搜索关键字</param>
        /// <param name="videoType">视频类型</param>
        /// <returns></returns>
        public ActionResult GetMovie(string searchKey, string videoType)
        {
            if (_Request == null) _Request = Request;
            Uri httpURL = new Uri("http://api.tudou.com/v3/gw?method=item.search&appKey=myKey&format=json&kw=" + searchKey + "&pageNo=1&pageSize=20&channelId=" + videoType + "&inDays=7&media=v&sort=s");
            System.Net.WebClient MyWebClient = new System.Net.WebClient();

            MyWebClient.Credentials = System.Net.CredentialCache.DefaultCredentials;           //获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(httpURL);

            return Content(Encoding.UTF8.GetString(pageData));
        }

        /// <summary>
        /// 图片在线管理
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImageManager(string action)
        {
            string[] paths = { "Image", "Other" }; //需要遍历的目录列表，最好使用缩略图地址，否则当网速慢时可能会造成严重的延时
            string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };
            String str = String.Empty;
            if (_Request == null) _Request = Request;
            if (action == "get")
            {
                string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                foreach (string path in paths)
                {
                    var cfg = UploadFileManager.GetUploadConfig("UEImage");
                    string basePath = WebHelper.MapPath("/") + pathFlag + cfg.Folder + pathFlag + path;
                    DirectoryInfo info = new DirectoryInfo(basePath);
                    //目录验证
                    if (info.Exists)
                    {
                        DirectoryInfo[] infoArr = info.GetDirectories();
                        foreach (DirectoryInfo tmpInfo in infoArr)
                        {
                            foreach (FileInfo fi in tmpInfo.GetFiles())
                            {
                                if (Array.IndexOf(filetype, fi.Extension) != -1)
                                {
                                    str += cfg.Folder + "/" + path + "/" + tmpInfo.Name + "/" + fi.Name + "ue_separate_ue";
                                }
                            }
                        }
                    }
                }
            }
            return Content(str);
        }

        /// <summary>
        /// 涂鸦
        /// </summary>
        /// <param name="upfile">图片文件</param>
        /// <param name="content">涂鸦内容</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ScrawlUp(IFormFile upfile, string content)
        {
            if (_Request == null) _Request = Request;
            var cfg = UploadFileManager.GetUploadConfig("UEImage");
            if (upfile != null)
            {
                string path = string.Empty;
                string state = "SUCCESS";
                //上传图片
                try
                {
                    path = UploadFile(upfile, "UEImage", "Temp");
                }
                catch (Exception ex)
                {
                    return Json(new { state = ex.Message });
                }
                return Content("<script>parent.ue_callback('" + path + "','" + state + "')</script>");//回调函数
            }
            else
            {
                //上传图片
                string url = string.Empty;
                string state = "SUCCESS";
                FileStream fs = null;
                string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                try
                {
                    string dir = WebHelper.MapPath("/") + pathFlag + cfg.Folder + pathFlag + "Other";
                    string path = DateTime.Now.ToString("yyyyMM");
                    dir = dir + pathFlag + path;
                    dir = dir.Replace("/", pathFlag);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filename = System.Guid.NewGuid() + ".png";
                    fs = System.IO.File.Create(dir + pathFlag + filename);
                    byte[] bytes = Convert.FromBase64String(content);
                    fs.Write(bytes, 0, bytes.Length);
                    url = cfg.Folder + "/Other/" + path + "/" + filename;
                }
                catch (Exception e)
                {
                    state = "未知错误:" + e.Message;
                    url = "";
                }
                finally
                {
                    fs.Close();
                    string tempDir = WebHelper.MapPath("/") + pathFlag + cfg.Folder + pathFlag + "Temp";
                    tempDir = tempDir.Replace("/", pathFlag);
                    DirectoryInfo info = new DirectoryInfo(tempDir);
                    if (info.Exists)
                    {
                        DirectoryInfo[] infoArr = info.GetDirectories();
                        foreach (var item in infoArr)
                        {
                            string str = tempDir + pathFlag + item.Name;
                            Directory.Delete(str, true);
                        }
                    }
                }
                return Json(new { url = url, state = state });
            }
        }
        #endregion

        #region 表单或文档附件处理

        /// <summary>
        /// 上传附件，兼容非表单附件
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public JsonResult UploadAttachment(IFormFileCollection file)
        {
            if (file == null || file.Count() == 0)
            {
                return Json(new ReturnResult { Success = false, Message = "请选择上传文件！" });
            }
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            Guid? moduleId = _Request.QueryEx("moduleId").ObjToGuidNull(); //模块Id,针对表单附件
            Guid? id = _Request.QueryEx("id").ObjToGuidNull(); //记录Id,针对表单附件
            bool isCreateSwf = _Request.QueryEx("isCreateSwf").ObjToBool(); //是否创建SWF文件
            string attachType = _Request.QueryEx("attachType").ObjToStr(); //附件类型
            string message = string.Empty;
            StringBuilder msg = new StringBuilder();
            List<AttachFileInfo> fileMsg = new List<AttachFileInfo>();
            foreach (var item in file)
            {
                try
                {
                    string fileSize = FileOperateHelper.FileSize(item.Length);
                    string fileType = Path.GetExtension(item.FileName);
                    string fileName = item.FileName;
                    string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                    int s = fileName.LastIndexOf(pathFlag);
                    if (s >= 0)
                    {
                        fileName = fileName.Substring(s + 1);
                    }
                    //保存文件
                    string filePath = string.Empty;
                    if (moduleId.HasValue) //表单附件
                    {
                        filePath = UploadFileManager.SaveAs(item, "Attachment", "Temp");
                    }
                    else
                    {
                        filePath = UploadFileManager.SaveAs(item, "Temp");
                    }
                    filePath = filePath.StartsWith("~/") ? filePath : filePath.StartsWith("/") ? "~" + filePath : "~/" + filePath;
                    //swf保存路径
                    string swfPath = string.Empty;
                    //pdf保存路径
                    string pdfPath = string.Empty;
                    if (isCreateSwf && !moduleId.HasValue)
                    {
                        //exe路径
                        string exePath = WebHelper.MapPath("~/bin/SWFTools/pdf2swf.exe");
                        //bin路径
                        string binPath = WebHelper.MapPath("~/bin/");
                        if (fileType.Equals(".doc") || fileType.Equals(".docx") ||
                            fileType.Equals(".xls") || fileType.Equals(".xlsx") ||
                            fileType.Equals(".ppt") || fileType.Equals(".pptx") ||
                            fileType.Equals(".pdf"))
                        {
                            //取pdf和swf路径
                            GetFilePath(out pdfPath, out swfPath);
                            //参数
                            string[] obj = new string[] { fileType, WebHelper.MapPath(filePath), WebHelper.MapPath(pdfPath), WebHelper.MapPath(swfPath), exePath, binPath };
                            CreateSwfFile(obj);
                        }
                    }
                    fileMsg.Add(new AttachFileInfo() { AttachFile = filePath, PdfFile = pdfPath, SwfFile = swfPath, FileName = fileName, FileType = fileType, FileSize = fileSize, AttachType = attachType });
                }
                catch (Exception ex)
                {
                    msg.AppendLine(item.FileName + "上传失败：" + ex.Message);
                    break;
                }
            }
            if (moduleId.HasValue && moduleId.Value != Guid.Empty && id.HasValue && id.Value != Guid.Empty) //查看页面，直接保存附件
            {
                return SaveFormAttach(moduleId.Value, id.Value, JsonHelper.Serialize(fileMsg), true);
            }
            return Json(new
            {
                Success = string.IsNullOrEmpty(msg.ToString()),
                Message = string.IsNullOrEmpty(msg.ToString()) ? "上传成功" : msg.ToString(),
                FileMsg = fileMsg.Count > 0 ? JsonHelper.Serialize(fileMsg) : string.Empty
            });
        }

        /// <summary>
        /// 保存表单附件
        /// </summary>
        /// <param name="moduleId">模块Id</param>
        /// <param name="id">记录Id</param>
        /// <param name="fileMsg">文件信息</param>
        /// <param name="isAdd">是否只是添加</param>
        /// <returns></returns>
        public JsonResult SaveFormAttach(Guid moduleId, Guid id, string fileMsg, bool isAdd = false)
        {
            if (string.IsNullOrEmpty(fileMsg))
            {
                return Json(new ReturnResult { Success = true, Message = string.Empty });
            }
            if (_Request == null) _Request = Request;
            SetRequest(_Request);
            string errMsg = string.Empty;
            List<AttachFileInfo> addAttachs = null;
            try
            {
                string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                UserInfo currUser = GetCurrentUser(_Request);
                Guid? userId = currUser != null ? currUser.UserId : (Guid?)null;
                string userName = currUser != null ? currUser.UserName : string.Empty;
                Sys_Module module = SystemOperate.GetModuleById(moduleId);
                List<AttachFileInfo> attachInfo = JsonHelper.Deserialize<List<AttachFileInfo>>(HttpUtility.UrlDecode(fileMsg, Encoding.UTF8));
                #region 删除已经移除的附件
                if (!isAdd) //非新增状态
                {
                    List<Guid> existIds = new List<Guid>();
                    if (attachInfo != null && attachInfo.Count > 0)
                    {
                        existIds = attachInfo.Select(x => x.Id.ObjToGuid()).Where(x => x != Guid.Empty).ToList();
                    }
                    //对已删除的附件进行处理
                    List<Sys_Attachment> tempAttachments = CommonOperate.GetEntities<Sys_Attachment>(out errMsg, x => x.Sys_ModuleId == moduleId && x.RecordId == id, null, false);
                    if (tempAttachments != null) tempAttachments = tempAttachments.Where(x => !existIds.Contains(x.Id)).ToList();
                    SystemOperate.DeleteAttachment(tempAttachments);
                }
                #endregion
                #region 添加附件
                if (attachInfo != null && attachInfo.Count > 0)
                {
                    addAttachs = new List<AttachFileInfo>();
                    //日期文件夹
                    string dateFolder = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);
                    //记录对应的titleKey值
                    string titleKeyValue = CommonOperate.GetModelTitleKeyValue(moduleId, id);
                    List<Sys_Attachment> list = new List<Sys_Attachment>();
                    foreach (AttachFileInfo info in attachInfo)
                    {
                        if (string.IsNullOrEmpty(info.AttachFile)) continue;
                        if (info.Id.ObjToGuid() != Guid.Empty) continue; //原来的附件
                        string oldAttchFile = WebHelper.MapPath(info.AttachFile); //临时附件
                        string dir = string.Format("{0}Upload{3}Attachment{3}{1}{3}{2}", Globals.GetWebDir(), module.TableName, dateFolder, pathFlag);
                        if (!Directory.Exists(dir)) //目录不存在则创建
                            Directory.CreateDirectory(dir);
                        string newAttachFile = string.Format("{0}{4}{1}_{2}{3}", dir, Path.GetFileNameWithoutExtension(info.FileName), id, Path.GetExtension(info.FileName), pathFlag);
                        try
                        {
                            System.IO.File.Copy(oldAttchFile, newAttachFile, true); //复制文件
                        }
                        catch (Exception ex)
                        {
                            return Json(new ReturnResult { Success = false, Message = ex.Message });
                        }
                        //文件复制完成后删除临时文件
                        try
                        {
                            System.IO.File.Delete(oldAttchFile);
                        }
                        catch { }
                        string newPdfFile = string.Empty; //pdf文件
                        string newSwfFile = string.Empty; //swf文件
                        //可以转换成swf的进行转换
                        if (info.FileType.Equals(".doc") || info.FileType.Equals(".docx") ||
                                info.FileType.Equals(".xls") || info.FileType.Equals(".xlsx") ||
                                info.FileType.Equals(".ppt") || info.FileType.Equals(".pptx") ||
                                info.FileType.Equals(".pdf"))
                        {
                            newPdfFile = string.Format("{0}{2}{1}.pdf", dir, Path.GetFileNameWithoutExtension(newAttachFile), pathFlag);
                            newSwfFile = string.Format("{0}{2}{1}.swf", dir, Path.GetFileNameWithoutExtension(newAttachFile), pathFlag);
                            string exePath = WebHelper.MapPath("~/bin/SWFTools/pdf2swf.exe");
                            string binPath = WebHelper.MapPath("~/bin/");
                            string[] obj = new string[] { info.FileType, newAttachFile, newPdfFile, newSwfFile, exePath, binPath };
                            CreateSwfFile(obj);
                        }
                        //构造文件URL，保存为相对URL地址
                        string fileUrl = string.Format("Upload/Attachment/{0}/{1}/{2}", module.TableName, dateFolder, Path.GetFileName(newAttachFile));
                        string pdfUrl = string.IsNullOrEmpty(newPdfFile) ? string.Empty : newPdfFile.Replace(Globals.GetWebDir(), string.Empty).Replace(pathFlag, "/");
                        string swfUrl = string.IsNullOrEmpty(newSwfFile) ? string.Empty : newSwfFile.Replace(Globals.GetWebDir(), string.Empty).Replace(pathFlag, "/");
                        Guid attachiId = Guid.NewGuid();
                        info.Id = attachiId.ToString();
                        list.Add(new Sys_Attachment()
                        {
                            Id = attachiId,
                            Sys_ModuleId = moduleId,
                            Sys_ModuleName = module.Name,
                            RecordId = id,
                            RecordTitleKeyValue = titleKeyValue,
                            FileName = info.FileName,
                            FileType = info.FileType,
                            FileSize = info.FileSize,
                            FileUrl = fileUrl,
                            PdfUrl = pdfUrl,
                            SwfUrl = swfUrl,
                            AttachType = info.AttachType,
                            CreateDate = DateTime.Now,
                            CreateUserId = userId,
                            CreateUserName = userName,
                            ModifyDate = DateTime.Now,
                            ModifyUserId = userId,
                            ModifyUserName = userName
                        });
                        string tempUrl = "/" + fileUrl;
                        if (!string.IsNullOrEmpty(swfUrl))
                        {
                            tempUrl = string.Format("/Page/DocView.html?fn={0}&swfUrl={1}", HttpUtility.UrlEncode(info.FileName).Replace("+", "%20"), HttpUtility.UrlEncode(swfUrl).Replace("+", "%20"));
                        }
                        info.AttachFile = tempUrl;
                        info.PdfFile = pdfUrl;
                        info.SwfFile = swfUrl;
                        addAttachs.Add(info);
                    }
                    if (list.Count > 0)
                    {
                        Guid attachModuleId = SystemOperate.GetModuleIdByName("附件信息");
                        bool rs = CommonOperate.OperateRecords(attachModuleId, list, ModelRecordOperateType.Add, out errMsg, false);
                        if (!rs)
                            addAttachs = null;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return Json(new { Success = string.IsNullOrEmpty(errMsg), Message = errMsg, AddAttachs = addAttachs });
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="attachIds">附件Id集合，多个以逗号分隔</param>
        /// <returns></returns>
        public JsonResult DeleteAttachment(string attachIds)
        {
            if (string.IsNullOrEmpty(attachIds))
            {
                return Json(new ReturnResult { Success = false, Message = "附件Id为空！" });
            }
            if (_Request == null) _Request = Request;
            string[] token = attachIds.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (token.Length == 0)
            {
                return Json(new ReturnResult { Success = false, Message = "附件Id为空！" });
            }
            List<Guid> delIds = token.Select(x => x.ObjToGuid()).Where(x => x != Guid.Empty).ToList();
            if (delIds == null || delIds.Count == 0)
            {
                return Json(new ReturnResult { Success = false, Message = "附件Id为空！" });
            }
            string errMsg = string.Empty;
            List<Sys_Attachment> tempAttachments = CommonOperate.GetEntities<Sys_Attachment>(out errMsg, x => delIds.Contains(x.Id), null, false);
            errMsg = SystemOperate.DeleteAttachment(tempAttachments);
            return Json(new ReturnResult { Success = string.IsNullOrEmpty(errMsg), Message = errMsg });
        }

        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="attachId">附件Id</param>
        /// <returns></returns>
        public ActionResult DownloadAttachment(Guid attachId)
        {
            if (_Request == null) _Request = Request;
            string errMsg = string.Empty;
            Sys_Attachment attachment = CommonOperate.GetEntityById<Sys_Attachment>(attachId, out errMsg);
            if (attachment != null)
            {
                try
                {
                    string pathFlag = System.IO.Path.DirectorySeparatorChar.ToString();
                    string tempFile = string.Format("{0}{1}", Globals.GetWebDir(), attachment.FileUrl.ObjToStr().Replace(Globals.GetBaseUrl(), string.Empty));
                    tempFile = tempFile.Replace("/", pathFlag);
                    string ext = FileOperateHelper.GetFileExt(tempFile);
                    var fs = new System.IO.FileStream(tempFile, FileMode.Open);
                    if (fs != null)
                    {
                        string tempfn = attachment.FileName;
                        if (Request.Headers["http_user_agent"].ObjToStr().IndexOf("firefox") == -1)
                            tempfn = HttpUtility.UrlEncode(tempfn, Encoding.UTF8);
                        else
                            tempfn = string.Format("\"{0}\"{1}", Path.GetFileNameWithoutExtension(tempfn), Path.GetExtension(tempfn));
                        return File(fs, FileOperateHelper.GetHttpMIMEContentType(ext), tempfn);
                    }
                }
                catch (Exception ex)
                {
                    return Content("<script>alert('异常：" + ex.Message + "');</script>");
                }
            }
            return Content("<script>alert('找不到此文件！');</script>");
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult DownloadFile(string fileName)
        {
            if (_Request == null) _Request = Request;
            try
            {
                var fs = new System.IO.FileStream(HttpUtility.UrlDecode(fileName, Encoding.UTF8), FileMode.Open);
                if (fs != null)
                {
                    string ext = FileOperateHelper.GetFileExt(fileName);
                    string tempfn = Path.GetFileName(fileName);
                    return File(fs, FileOperateHelper.GetHttpMIMEContentType(ext), tempfn);
                }
                else
                {
                    return Content("<script>alert('找不到此文件！');</script>");
                }
            }
            catch (Exception ex)
            {
                return Content("<script>alert('异常：" + ex.Message + "');</script>");
            }
        }

        #endregion

        #region 图片控件临时上传

        /// <summary>
        /// 上传临时图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadTempImage(IFormFile file)
        {
            if (file == null)
            {
                return Json(new ReturnResult { Success = false, Message = "请选择上传文件！" });
            }
            if (_Request == null) _Request = Request;
            string message = string.Empty;
            string imgName = _Request.QueryEx("imgName").ObjToStr();
            try
            {
                string fileSize = FileOperateHelper.FileSize(file.Length);
                string fileType = Path.GetExtension(file.FileName);
                //保存文件
                string filePath = UploadFileManager.SaveAs(file, string.Empty, "Temp", imgName);
                if (!string.IsNullOrEmpty(filePath) && filePath.Substring(0, 1) != "/")
                {
                    filePath = "/" + filePath;
                }
                else
                {
                    message = "临时图片保存失败！";
                }
                return Json(new { Success = string.IsNullOrEmpty(message), Message = message, FilePath = filePath });
            }
            catch (Exception ex)
            {
                message = string.Format("图片上传失败，原因：{0}", ex.Message);
                return Json(new ReturnResult { Success = false, Message = message });
            }
        }

        #endregion

        #region 数据导入临时文件上传

        /// <summary>
        /// 上传临时导入模板文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public JsonResult UploadTempImportFile(IFormFile file)
        {
            if (file == null)
            {
                return Json(new ReturnResult { Success = false, Message = "请选择上传文件！" });
            }
            if (_Request == null) _Request = Request;
            string message = string.Empty;
            try
            {
                string fileSize = FileOperateHelper.FileSize(file.Length);
                string fileType = Path.GetExtension(file.FileName);
                //保存文件
                string filePath = UploadFileManager.SaveAs(file, string.Empty, "Temp");
                if (string.IsNullOrWhiteSpace(filePath)) message = "上传失败！";
                return Json(new { Success = string.IsNullOrEmpty(message), Message = message, FilePath = filePath });
            }
            catch (Exception ex)
            {
                message = string.Format("上传失败，异常：{0}", ex.Message);
                return Json(new ReturnResult { Success = false, Message = message });
            }
        }

        #endregion
    }
}
