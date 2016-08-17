using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad.Tests
{
    [TestClass()]
    public class MyQuadTests
    {
        [TestMethod()]
        public void SolveNoRootsTest()
        {
            var quad = new MyQuad(new double[] { 1.0, 2.0, 3.0 });
            Assert.AreEqual(0, quad.Solve().Count);
        }
        [TestMethod()]
        public void SolveOneRootTest()
        {
            var quad = new MyQuad(new double[] { 1.0, 4.0, 4.0 });
            Assert.AreEqual(1, quad.Solve().Count);
        }
        [TestMethod()]
        public void SolveTwoRootsTest()
        {
            var quad = new MyQuad(new double[] { 1.0, -5.0, 6.0 });
            var ans = quad.Solve();
            Assert.AreEqual(2, ans.Count);
            Assert.AreEqual(2, ans[0]);
            Assert.AreEqual(3, ans[1]);
        }
    }
}