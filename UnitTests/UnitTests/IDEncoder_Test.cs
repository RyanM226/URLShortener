using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BL;

namespace EncoderTests
{
    [TestClass]
    public class IDEncoder_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeTest_NullParameter()
        {
            IDEncoder.Decode(null);
        }

        [TestMethod]
        public void EncodeTest_0Param()
        {
            string encoded = IDEncoder.Encode(0);
            Assert.AreEqual(encoded, "a");
        }

        [TestMethod]
        public void DecodeTest_aParam()
        {
            int decoded = IDEncoder.Decode("a");
            Assert.AreEqual(decoded, 0);
        }

        [TestMethod]
        public void EncodeTest_123Param()
        {
            string encoded = IDEncoder.Encode(123);
            Assert.AreEqual(encoded, "dp");
        }

        [TestMethod]
        public void DecodeTest_dpParam()
        {
            int decoded = IDEncoder.Decode("dp");
            Assert.AreEqual(decoded, 123);
        }
    }
}
