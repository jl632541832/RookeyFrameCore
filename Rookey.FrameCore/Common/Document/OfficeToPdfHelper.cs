/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using System;

namespace Rookey.Frame.Common
{
    /// <summary>
    /// office转PDF工具类
    /// </summary>
    public class OfficeToPdfHelper
    {
        /// <summary>  Word转换成pdf </summary> 
        /// <param name="sourcePath">源文件路径</param> 
        /// <param name="targetPath">目标文件路径</param> 
        /// <returns>true=转换成功</returns>     
        public static bool Doc2Pdf(string sourcePath, string targetPath)
        {
            bool result = false;
            try
            {
                
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;

            }
            finally
            {
                
            }
            return result;
        }

        /// <summary>把Excel文件转换成PDF格式文件</summary>  
        /// <param name="sourcePath">源文件路径</param>  
        /// <param name="targetPath">目标文件路径</param> 
        /// <returns>true=转换成功</returns>      
        public static bool Xls2Pdf(string sourcePath, string targetPath)
        {
            bool result = false;
            try
            {
                
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
            }
            return result;
        }

        ///<summary>把PowerPoint文件转换成PDF格式文件</summary>     
        ///<param name="sourcePath">源文件路径</param>      
        ///<param name="targetPath">目标文件路径</param>    
        ///<returns>true=转换成功</returns>     
        public static bool PPt2Pdf(string sourcePath, string targetPath)
        {
            bool result=false;
            try
            {
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
            }
            return result;
        }
    }
}
