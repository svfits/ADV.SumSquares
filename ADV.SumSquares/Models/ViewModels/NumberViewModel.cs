using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.SumSquares.Models
{
    public class NumberViewModel
    {
        [Required(ErrorMessage = "Должны обязательно указаны числовые значения")]
        [Remote(action: "CheckNumber", controller: "Home", ErrorMessage = "Такое число невозможно использовать")]
        public int[] Numbers { get; set; }

        public ParametersOptions ParametersOptions { get; set; }
    }
}
