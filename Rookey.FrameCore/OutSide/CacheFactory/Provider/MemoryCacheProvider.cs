/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using System.Collections.Concurrent;

namespace Rookey.Frame.Cache.Factory.Provider
{
    /// <summary>
    /// 内存缓存提供器
    /// </summary>
    public class MemoryCacheProvider : ICacheProvider
    {
        /// <summary>
        /// 缓存对象
        /// </summary>
        private static ConcurrentDictionary<string, object> ObjectCache = new ConcurrentDictionary<string, object>();

        #region 单键值

        /// <summary>
        /// 向缓存中添加一个对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="value">需要缓存的对象。</param>
        public void Add(string key, object value)
        {
            try
            {
                ObjectCache.TryAdd(key, value);
            }
            catch { }
        }

        /// <summary>
        /// 向缓存中添加一个对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="value">需要缓存的对象。</param>
        public void Add<T>(string key, T value)
        {
            Add(key, value as object);
        }

        /// <summary>
        /// 向缓存中更新一个对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="value">需要缓存的对象。</param>
        public void Set(string key, object value)
        {
            Add(key, value);
        }

        /// <summary>
        /// 向缓存中更新一个对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="value">需要缓存的对象。</param>
        public void Set<T>(string key, T value)
        {
            Set(key, value as object);
        }

        /// <summary>
        /// 从缓存中读取对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <returns>被缓存的对象。</returns>
        public T Get<T>(string key)
        {
            object obj = Get(key);
            return obj == null ? default(T) : (T)obj;
        }

        /// <summary>
        /// 从缓存中读取对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <returns>被缓存的对象。</returns>
        public object Get(string key)
        {
            object obj = null;
            try
            {
                ObjectCache.TryGetValue(key, out obj);
            }
            catch { }
            return obj;
        }

        /// <summary>
        /// 从缓存中移除对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        public void Remove(string key)
        {
            try
            {
                object obj = null;
                ObjectCache.TryRemove(key, out obj);
            }
            catch { }
        }

        /// <summary>
        /// 获取一个值，该值表示拥有指定键值的缓存是否存在。
        /// </summary>
        /// <param name="key">指定的键值。</param>
        /// <returns>如果缓存存在，则返回true，否则返回false。</returns>
        public bool Exists(string key)
        {
            return ObjectCache.ContainsKey(key);
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public void FlushAll()
        {
            ObjectCache.Clear();
        }

        #endregion
    }
}
