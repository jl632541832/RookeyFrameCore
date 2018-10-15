/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rookey.Frame.Cache.Factory.Provider
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheProviderType
    {
        /// <summary>
        /// 本地缓存
        /// </summary>
        LOCALMEMORYCACHE = 0,
        /// <summary>
        /// ServiceStack redis缓存
        /// </summary>
        ServiceStackREDIS = 1
    }
}
