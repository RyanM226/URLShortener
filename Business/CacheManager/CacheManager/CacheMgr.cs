using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CacheMgr
    {
        ObjectCache _cache { get { return MemoryCache.Default; }}

        #region objectCreation
        //Create a Singleton of this object
        private static volatile CacheMgr _instance;
        private static object m_syncRoot = new object();
        /// <summary>
        /// Create a Singleton of this object
        /// </summary>
        public static CacheMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (m_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new CacheMgr();
                        }
                    }
                }
                return _instance;
            }
        }

        private CacheMgr()
        {
        }
        #endregion

        public TBL_URL GetFromCache(string cacheKey)
        {
            try
            {
                return _cache.Get(cacheKey, null) as TBL_URL;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public TBL_URL GetFromCache(int cacheKey)
        {
            return GetFromCache(cacheKey.ToString());
        }

        public bool SetInCache(TBL_URL data)
        {
            try
            {
                //24 hour cache time
                CacheItemPolicy cip = new CacheItemPolicy()
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(1440))
                };
                _cache.Set(data.ID.ToString(), data, cip);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
