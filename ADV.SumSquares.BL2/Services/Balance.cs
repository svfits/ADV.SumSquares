using ADV.SumSquares.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL.Services
{
    public class Balance : IBalance
    {
        public int GetBalance()
        {
            return 450;
        }
    }
}
