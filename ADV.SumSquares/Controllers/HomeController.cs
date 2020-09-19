﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADV.SumSquares.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ADV.SumSquares.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private readonly ParametersOptions _options;

        public HomeController(IOptions<ParametersOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Проверка числа на диапозон вхождения
        /// </summary>
        /// <param name="Numbers"></param>
        /// <returns></returns>
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckNumber(int Numbers)
        {
            if (Numbers < _options.MinValue || Numbers > _options.MaxValue)
            {
                return Json(false);
            }

            return Json(true);
        }

        /// <summary>
        /// Отправить на расчет числа 
        /// </summary>
        /// <param name="Numbers"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalculationSquares([FromForm] List<int> Numbers)
        {
            Debug.WriteLine(Numbers.FirstOrDefault());
            return View();
        }

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
