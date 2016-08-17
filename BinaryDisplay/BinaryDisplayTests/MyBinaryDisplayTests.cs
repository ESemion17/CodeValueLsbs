using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay.Tests
{
    [TestClass()]
    public class MyBinaryDisplayTests
    {
        [TestMethod()]
        public void CountOnesTest()
        {
            var binaryDisplay = new MyBinaryDisplay(10);
            Assert.AreEqual(2, binaryDisplay.CountOnes());
        }

        [TestMethod()]
        public void ConvertToBinaryTest()
        {
            var binaryDisplay = new MyBinaryDisplay(10);
            Assert.AreEqual("1010", binaryDisplay.ConvertToBinary());
        }
    }
}