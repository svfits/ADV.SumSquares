using System;
using System.Collections.Generic;

namespace ADV.SumSquares.BL
{
    /// <summary>
    /// Класс для кеширования и выдачи результатов расчетов
    /// </summary>
    public class СachingProxy
    {
        private List<int> _numbers;

        private static Dictionary<int, int> CachData;

        public СachingProxy(List<int> numbers)
        {
           this._numbers = numbers;
        }

        public Dictionary<int, int> GetСachingData()
        {
            throw new NotImplementedException();
        }
    }
}
