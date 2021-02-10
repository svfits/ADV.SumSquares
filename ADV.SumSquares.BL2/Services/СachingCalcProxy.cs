using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL
{
    /// <summary>
    /// Класс для кеширования и выдачи результатов расчетов
    /// </summary>
    public class СachingCalcProxy : IСachingCalcProxy
    {
        private readonly Random _random;
        private readonly int _maxpause;
        private readonly int _minpause;
        private static readonly ConcurrentDictionary<int, int> CachData;
        private static readonly List<string> History;

        static СachingCalcProxy()
        {
            CachData = new ConcurrentDictionary<int, int>();
            History = new List<string>();
        }

        public СachingCalcProxy(Random random, int minPause, int maxPause)
        {
            CachData.Clear();
            _random = random;
            _maxpause = maxPause;
            _minpause = minPause;
        }

        /// <summary>
        /// Получить данные из кеша или сгенерировать
        /// </summary>
        /// <returns></returns>
        public (int Total, List<string> History) GetСachingData(List<int> numbers)
        {
            int total = 0;

            Parallel.ForEach(numbers,
                                  () => 0,
                                  (j, loop, subtotal) =>
                                     {
                                         var ifCach = CachData.TryGetValue(j, out int value);

                                         if (ifCach)
                                         {
                                             subtotal += value;
                                             Debug.WriteLine("Есть в кеше " + subtotal);
                                         }
                                         else
                                         {
                                             subtotal += GetSqr(j);
                                             Debug.WriteLine("Нет в кеше " + subtotal);
                                         }

                                         return subtotal;
                                     },
                                  (finalResult) => Interlocked.Add(ref total, finalResult)
                                  );

            SaveFormatHistory(numbers, total);

            return (total, History);
        }

        /// <summary>
        /// Получить квадрат числа и сохранить в кеше
        /// </summary>
        /// <param name="number"></param>
        private int GetSqr(int number)
        {
            var pause = _random.Next(_minpause, _maxpause);

            Thread.Sleep(pause);
            var sqr = number * number;

            CachData.TryAdd(number, sqr);

            return sqr;
        }

        /// <summary>
        /// Сохранить в истории отформатированную строку результат работы
        /// </summary>
        /// <param name="Numbers"></param>
        /// <param name="data"></param>
        private static void SaveFormatHistory(List<int> Numbers, int data)
        {
            var strFormat = new List<string>();

            foreach (var item in Numbers)
            {
                strFormat.Add(item + "*" + item);
            }

            History.Add(string.Join(" + ", strFormat) + " = " + data);
        }
    }
}

