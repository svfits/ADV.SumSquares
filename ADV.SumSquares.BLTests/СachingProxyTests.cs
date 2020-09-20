using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADV.SumSquares.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace ADV.SumSquares.BL.Tests
{
    [TestClass()]
    public class СachingProxyTests
    {
        public СachingProxyTests()
        {
            NumbersMock = Enumerable.Range(0, 10).ToList();
            Random = new Random();
        }

        private List<int> NumbersMock { get; }

        private Random Random { get; }

        private const int MinPause = 1340;
        private const int MaxPause = 7340;

        /// <summary>
        /// Получение данных из "Холодного кеша"
        /// </summary>
        [TestMethod()]
        public void GetСachingData_СoldData_Test()
        {
            СachingCalcProxy сachingProxy = new СachingCalcProxy(Random, MinPause, MaxPause);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var data = сachingProxy.GetСachingData(NumbersMock);
            stopWatch.Stop();

            var timeElapsed = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(data == 285);
            Assert.IsFalse(timeElapsed > MaxPause);
        }

        /// <summary>
        /// Получение данных из "Прогретого кеша" полное совпадение кеша и данных
        /// </summary>
        [TestMethod()]
        public void GetСachingData_HotData_TrueTest()
        {
            СachingCalcProxy сachingProxy = new СachingCalcProxy(Random, MinPause, MaxPause);

            сachingProxy.GetСachingData(NumbersMock);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var data = сachingProxy.GetСachingData(NumbersMock);

            stopWatch.Stop();
            var timeElapsed = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(data == 285);
            Assert.IsTrue(timeElapsed < MinPause);
        }

        /// <summary>
        /// Получение данных из не полного кеша
        /// </summary>
        [TestMethod()]
        public void GetСachingData_NotComplectedData_TrueTest()
        {
            СachingCalcProxy сachingProxy = new СachingCalcProxy(Random, MinPause, MaxPause);

            var numberMock = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            сachingProxy.GetСachingData(NumbersMock);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var data = сachingProxy.GetСachingData(numberMock);

            stopWatch.Stop();
            var timeElapsed = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(data == 204);
            Assert.IsTrue(timeElapsed < MaxPause);
        }
    }
}