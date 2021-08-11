using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DBHandler
    {
        public virtual List<TBL_URL> GetAllFromTblUrl()
        {
            using (URLShortenerEntities _database = new URLShortenerEntities())
            {
                List<TBL_URL> rows = (from sel in _database.TBL_URL select sel).ToList();
                return rows;
            }
        }

        public virtual int Insert(TBL_URL row)
        {
            using (URLShortenerEntities _database = new URLShortenerEntities())
            {
                _database.TBL_URL.Add(row);

                _database.ChangeTracker.HasChanges();
                _database.SaveChanges();
                return row.ID;
            }
        }

        public void Update(TBL_URL row)
        {
            using (URLShortenerEntities _database = new URLShortenerEntities())
            {
                TBL_URL rowInDB = (from dbRow in _database.TBL_URL
                                where dbRow.ID == row.ID
                                select dbRow).FirstOrDefault();

                if(rowInDB != null)
                {
                    rowInDB.LONG_URL = row.LONG_URL;
                    rowInDB.SHORT_URL = row.SHORT_URL;
                    var changes = _database.ChangeTracker.HasChanges();
                    _database.SaveChanges();
                }
            }
        }

        public virtual TBL_URL GetUsingLongURL(string URL)
        {
            using (URLShortenerEntities _database = new URLShortenerEntities())
            {
                TBL_URL rows = (from row in _database.TBL_URL
                                where row.LONG_URL == URL
                                select row).FirstOrDefault();
                return rows;
            }
        }

        public virtual TBL_URL GetUsingRowID(int RowID)
        {
            using (URLShortenerEntities _database = new URLShortenerEntities())
            {
                TBL_URL rows = (from row in _database.TBL_URL
                                where row.ID == RowID
                                select row).FirstOrDefault();
                return rows;
            }
        }
    }
}
