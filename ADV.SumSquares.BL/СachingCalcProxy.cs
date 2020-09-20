using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL
{
    /// <summary>
    /// Класс для кеширования и выдачи результатов расчетов
    /// </summary>
    public class СachingCalcProxy
    {
        private readonly Random _random;
        private readonly int _maxpause;
        private readonly int _minpause;
        private static readonly Dictionary<int, int> CachData;

        static СachingCalcProxy()
        {
            CachData = new Dictionary<int, int>();
        }

        public СachingCalcProxy(Random random, int minPause, int maxPause)
        {
            _random = random;
            _maxpause = maxPause;
            _minpause = minPause;
        }

        /// <summary>
        /// Получить данные из кеша или сгенерировать
        /// </summary>
        /// <returns></returns>
        public int GetСachingData(List<int> numbers)
        {
            var expectNumbers = numbers.Except(CachData.Select(a => a.Key)).ToList();

            Parallel.ForEach(expectNumbers, i => GetSqr(i));

            var intersectNumbers = CachData.Where(z => numbers.Contains(z.Key))
                                   .Sum(q => q.Value);

            return intersectNumbers;
        }

        private void GetSqr(int number)
        {
            var pause = _random.Next(_minpause, _maxpause);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Thread.Sleep(pause);

            stopWatch.Stop();
            Debug.WriteLine(number + " прошло времени " + stopWatch.ElapsedMilliseconds);

            CachData.Add(number, number * number);
        }
    }
}

