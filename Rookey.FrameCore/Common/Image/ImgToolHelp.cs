using System;
using System.Net;

namespace Cecport.Frame.Common
{
    /// <summary>
    /// 图片工具帮助类
    /// </summary>
    public class ImgToolHelp
    {
        /// <summary>
        /// 判断网络图片是否存在
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static bool InternetImgIsExists(string imgUrl)
        {
            bool result = false;//下载结果
            WebResponse response = null;
            try
            {
                WebRequest req = WebRequest.Create(imgUrl);
                response = req.GetResponse();
                result = response == null ? false : true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }
    }
}
