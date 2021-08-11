using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BL
{
    public class URLManager
    {
        public DBHandler _dbHandler { get; set; }
        #region objectCreation
        //Create a Singleton of this object
        private static volatile URLManager _instance;
        private static object m_syncRoot = new object();
        /// <summary>
        /// Create a Singleton of this object
        /// </summary>
        public static URLManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (m_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new URLManager(new DBHandler());
                        }
                    }
                }
                return _instance;
            }
        }

        private URLManager(DBHandler dBHandler)
        {
            _dbHandler = dBHandler;
        }
        #endregion

        /// <summary>
        /// Function to return all records from TBL_URL
        /// </summary>
        /// <returns></returns>
        public List<TBL_URL> GetAllRecords()
        {
            try
            {
                return _dbHandler.GetAllFromTblUrl();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<TBL_URL>();
            }
        }

        /// <summary>
        /// Function to return an long url from a given short ("encoded") URL
        /// </summary>
        /// <param name="encodedURL"> string representing encoded rowID </param>
        /// <returns></returns>
        public string GetExistingShortenedURL(string encodedURL)
        {
            if(string.IsNullOrWhiteSpace(encodedURL))
            {
                Debug.WriteLine("Empty encodedURL");
                return String.Empty;
            }

            try
            {
                DBHandler dBHandler = new DBHandler();
                TBL_URL dbRow = new TBL_URL();
                int rowID = IDEncoder.Decode(encodedURL);

                if (rowID > 0)
                {
                    dbRow = CacheMgr.Instance.GetFromCache(rowID);
                    if (dbRow == null)
                    {
                        dbRow = dBHandler.GetUsingRowID(rowID);
                        if(dbRow != null)
                        {
                            CacheMgr.Instance.SetInCache(dbRow);
                        }                        
                    }
                    return dbRow?.LONG_URL ?? null;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// Function to create a shortened URL from a given "Long" URL. 
        /// </summary>
        /// <param name="baseURL"> The URL of the application website </param>
        /// <param name="LongURL"> The "long" URL required to be shortened </param>
        /// <returns></returns>
        public string CreateShortenedURL(string baseURL, string LongURL)
        {
            try
            {
                //Check if URL exists already in DB
                

                TBL_URL dbRow = _dbHandler.GetUsingLongURL(LongURL);
                if (dbRow == null)
                {
                    dbRow = new TBL_URL();
                    dbRow.LONG_URL = LongURL;
                    dbRow.ID = _dbHandler.Insert(dbRow);
                }

                string encoded = IDEncoder.Encode(dbRow.ID);
                return ShortURLBuilder.BuildShortURL(baseURL, encoded);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return String.Empty;
        }
    }
}
