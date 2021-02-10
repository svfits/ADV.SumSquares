using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL.Interfaces
{
    public interface IDeliveryGoods
    {
        bool DeliveryAge(int IdUser);

        bool Payment();
    }
}
