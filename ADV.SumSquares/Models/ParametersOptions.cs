using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.SumSquares.Models
{
    public class ParametersOptions
    {
        public const string Parameters = "Parameters";

        /// <summary>
        ////Минимальное значение числа
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// Максимальное значение числа
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// Максимальное количество аргументов
        /// </summary>
        public int MaxArguments { get; set; }

        /// <summary>
        /// Минимальная задержка
        /// </summary>
        public int MinPause { get; set; }

        /// <summary>
        /// Максимальная задержка
        /// </summary>
        public int MaxPause { get; set; }
    }
}
