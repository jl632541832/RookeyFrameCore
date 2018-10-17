/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rookey.Frame.Office
{
    /// <summary>
    /// 新建类 重写Npoi流方法
    /// </summary>
    public class NpoiMemoryStream : MemoryStream
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public NpoiMemoryStream()
        {
            AllowClose = true;
        }
        /// <summary>
        /// 是否允许关闭流
        /// </summary>
        public bool AllowClose { get; set; }
        /// <summary>
        /// 关闭流
        /// </summary>
        public override void Close()
        {
            if (AllowClose)
                base.Close();
        }
    }
}
