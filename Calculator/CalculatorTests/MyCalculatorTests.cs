using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class MyCalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var calc = new MyCalculator(1, 2);
            Assert.AreEqual(3, calc.Add());
        }

        [TestMethod()]
        public void SubstractTest()
        {
            var calc = new MyCalculator(1, 2);
            Assert.AreEqual(-1, calc.Substract());
        }

        [TestMethod()]
        public void MultTest()
        {
            var calc = new MyCalculator(1, 2);
            Assert.AreEqual(2, calc.Mult());
        }

        [TestMethod()]
        public void DivideTest()
        {
            var calc = new MyCalculator(1, 2);
            Assert.AreEqual(0.5, calc.Divide());
        }
        [TestMethod()]
        public void DivideByZeroTest()
        {
            var calc = new MyCalculator(1, 0);
            try
            {
                calc.Divide();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual((new DivideByZeroException()).Message, ex.Message);
            }
            
        }
    }
}