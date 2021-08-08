using BL;
using DAL.Models;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLManagerTests
{
    [TestClass]
    public class URLManagerTest
    {
        [TestMethod]
        public void URLManager_GetFromDB_Test()
        {
            List<TBL_URL> resultList = new List<TBL_URL>();
            for (int i = 0; i <= 2; i++)
            {
                TBL_URL obj = new TBL_URL();
                obj.ID = i;
                resultList.Add(obj);
            }
            var mockObj = new Mock<DBHandler>();
            mockObj.Setup(x => x.GetAllFromTblUrl()).Returns(() => resultList);
            URLManager.Instance._dbHandler = mockObj.Object;
            var allRecords = URLManager.Instance.GetAllRecords();
            Assert.AreEqual(3, allRecords.Count);
        }

        [TestMethod]
        public void URLManager_CreateNewShortenedURLTest()
        {
            List<TBL_URL> resultList = new List<TBL_URL>();
            for (int i = 0; i <= 2; i++)
            {
                TBL_URL obj = new TBL_URL();
                obj.ID = i;
                resultList.Add(obj);
            }
            var mockObj = new Mock<DBHandler>();
            mockObj.Setup(x => x.Insert(It.IsAny<TBL_URL>())).Returns(() => 1);
            mockObj.Setup(x => x.GetUsingLongURL(It.IsAny<string>())).Returns(() => null);
            URLManager.Instance._dbHandler = mockObj.Object;
            var shortURL = URLManager.Instance.CreateShortenedURL("MyBaseURL", "www.google.com");
            Assert.AreEqual("MyBaseURL/b", shortURL);
        }
    }
}
