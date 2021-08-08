using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURLBuilderTests
{
    [TestClass]
    public class ShortURLBuilder_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShortURLBuilder_NullBaseURLParamTest()
        {
            var URL = ShortURLBuilder.BuildShortURL(null, "MyEncodedString");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShortURLBuilder_NullEncodedParamTest()
        {
            var URL = ShortURLBuilder.BuildShortURL("MyBaseURL", null);
        }

        [TestMethod]
        public void ShortURLBuilder_BuildShortURLTest()
        {
            var URL = ShortURLBuilder.BuildShortURL("MyBaseURL", "MyEncodedString");
            Assert.AreEqual("MyBaseURL/MyEncodedString", URL);
        }

        [TestMethod]
        public void ShortURLBuilder_BuildShortURL_SlashTrim_Test()
        {
            var URL = ShortURLBuilder.BuildShortURL("MyBaseURL/", "MyEncodedString");
            Assert.AreEqual("MyBaseURL/MyEncodedString", URL);
        }

    }
}
