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
            this.NumbersMock = Enumerable.Range(0, 10).ToList();
            this.Random = new Random();
        }

        private List<int> NumbersMock { get; }
        private Random Random { get; }

        private const int MinPause = 1340;
        private const int MaxPause = 7340;

        [TestMethod()]
        public void GetСachingDataTest()
        {
            СachingCalcProxy сachingProxy = new СachingCalcProxy(NumbersMock, Random, MinPause, MaxPause);
            var data = сachingProxy.GetСachingData();

            Assert.IsFalse(data != 285);
        }
    }
}