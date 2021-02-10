using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADV.SumSquares.BL.Tests
{
    [TestClass()]
    public class СachingProxyTests
    {
        private СachingCalcProxy сachingProxy;
        private List<int> NumbersMock;
        private const int MinPause = 1340;
        private const int MaxPause = 7340;

        [TestInitialize]
        public void InitTest()
        {
            NumbersMock = Enumerable.Range(0, 10).ToList();
            сachingProxy = new СachingCalcProxy(new Random(), MinPause, MaxPause);
        }
        
        [TestMethod("Получение данных из 'Холодного кеша'")]
        public void GetСachingData_СoldData_Test()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var (Total, History) = сachingProxy.GetСachingData(NumbersMock);
            stopWatch.Stop();

            var timeElapsed = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(Total == 285);
            Assert.IsTrue(History.Any());
            Assert.IsFalse(timeElapsed > MaxPause);
        }
                
        [TestMethod("Получение данных из 'Прогретого' кеша полное совпадение кеша и данных")]
        public void GetСachingData_HotData_TrueTest()
        {
            сachingProxy.GetСachingData(NumbersMock);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var (Total, History) = сachingProxy.GetСachingData(NumbersMock);

            stopWatch.Stop();
            var timeElapsed = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(Total == 285);
            Assert.IsTrue(History.Any());
            Assert.IsTrue(timeElapsed < MinPause);
        }

        
        [TestMethod("Получение данных из не полного кеша")]
        public void GetСachingData_NotComplectedData_TrueTest()
        {
            var numberMock = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            сachingProxy.GetСachingData(NumbersMock);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var (Total, History) = сachingProxy.GetСachingData(numberMock);

            stopWatch.Stop();
            var timeElapsed = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(Total == 204);
            Assert.IsTrue(History.Any());
            Assert.IsTrue(timeElapsed < MaxPause);
        }
    }
}