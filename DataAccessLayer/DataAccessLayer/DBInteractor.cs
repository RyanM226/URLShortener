using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBInteractor
    {
        URLShortenerEntities _database
        {
            get { return new URLShortenerEntities(); }
        }
        public List<TBL_URL> GetAllFromTblUrl()
        {
            
            using (_database)
            {
                TBL_URL objDT = (from sel in x.TBL_URL

                                 select sel).FirstOrDefault();
            }
        }
    }
}
