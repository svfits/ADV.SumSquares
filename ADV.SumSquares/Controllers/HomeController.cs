using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADV.SumSquares.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ADV.SumSquares.BL;
using System.Xml.Schema;

namespace ADV.SumSquares.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private readonly ParametersOptions _options;
        private readonly IСachingCalcProxy _сachingCalcProxy;

        public HomeController(IOptions<ParametersOptions> options, IСachingCalcProxy сachingCalcProxy)
        {
            _options = options.Value;
            _сachingCalcProxy = сachingCalcProxy;
        }

        /// <summary>
        /// Проверка числа на диапазон вхождения
        /// </summary>
        /// <param name="Numbers"></param>
        /// <returns></returns>
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckNumber(int Numbers)
        {
            if (Numbers < _options.MinValue || Numbers > _options.MaxValue)
            {
                return Json($"Данное число {Numbers} не возможно использовать!.");
            }

            return Json(true);
        }

        /// <summary>
        /// Отправить на расчет числа 
        /// </summary>
        /// <param name="Numbers"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CalculationSquaresAsync(List<int> Numbers)
        {
            var erMaxVal = Numbers.Any(qw => qw > _options.MaxValue);
            if (erMaxVal)
            {
                return Json(new { Total = "", History = "", ErrorMessage = "Превышено максимальное значение числа " + _options.MaxValue });
            }

            var erMinVal = Numbers.Any(qw => qw < _options.MinValue);
            if (erMinVal)
            {
                return Json(new { Total = "", History = "", ErrorMessage = "Меньше минимального значения числа " + _options.MinValue });
            }

            var erNumCount = Numbers.Count() > _options.MaxArguments;
            if (erNumCount)
            {
                return Json(new { Total = "", History = "", ErrorMessage = "Превышено максимальное значение количество элементов " + _options.MaxArguments });
            }

            var (Total, History) = await Task.Run(() => _сachingCalcProxy.GetСachingData(Numbers));

            var result = new { Total, History, ErrorMessage = "" };

            return Json(result);
        }

        [HttpGet]
        public IActionResult Number()
        {
            var numberViewModel = new NumberViewModel
            {
                ParametersOptions = _options
            };
            return View(numberViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
