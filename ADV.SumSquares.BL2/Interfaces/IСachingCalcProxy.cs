using System;
using System.Collections.Generic;
using System.Text;

namespace ADV.SumSquares.BL
{
    public interface IСachingCalcProxy
    {
        (int Total, List<string> History) GetСachingData(List<int> numbers);
    }
}
