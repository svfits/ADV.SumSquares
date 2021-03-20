using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL.Exceptions
{
    public class NoHolidayToday : Exception
    {
        public NoHolidayToday(string message) : base(message)
        {

        }
    }
}
