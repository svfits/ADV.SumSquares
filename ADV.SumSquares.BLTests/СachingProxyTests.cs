using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADV.SumSquares.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ADV.SumSquares.BL.Tests
{
    [TestClass()]
    public class СachingProxyTests
    {
        public СachingProxyTests()
        {
            this.NumbersMock = Enumerable.Range(0, 100).ToList();
        }

        private List<int> NumbersMock { get; }

        [TestMethod()]
        public void GetСachingDataTest()
        {
            СachingProxy сachingProxy = new СachingProxy(NumbersMock);
            var data = сachingProxy.GetСachingData();

            Assert.Fail();
        }
    }
}