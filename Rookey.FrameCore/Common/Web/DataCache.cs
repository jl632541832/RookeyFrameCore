using System.Collections.Concurrent;

namespace Rookey.Frame.Common
{
    /// <summary>
    /// 简单缓存操作类
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// 缓存对象
        /// </summary>
        private static ConcurrentDictionary<string, object> ObjectCache = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            object obj = null;
            try
            {
                ObjectCache.TryGetValue(CacheKey, out obj);
            }
            catch { }
            return obj;
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            try
            {
                ObjectCache.TryAdd(CacheKey, objObject);
            }
            catch { }
        }
    }
}
