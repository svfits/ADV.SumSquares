using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL.Exceptions
{
    public class NotAgeOrderExceptions : Exception
    {
        public NotAgeOrderExceptions(string message) : base(message)
        {

        }
    }
}
