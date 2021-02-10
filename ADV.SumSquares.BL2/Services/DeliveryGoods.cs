using ADV.Model.EF;
using ADV.SumSquares.BL.Exceptions;
using ADV.SumSquares.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL.Services
{
    public class DeliveryGoods : IDeliveryGoods
    {
        private readonly DataContextApp db;
        private readonly IBalance balance;

        public DeliveryGoods(DataContextApp db, IBalance balance)
        {
            this.db = db;
            this.balance = balance;
        }

        public bool DeliveryAge(int IdUser)
        {
            var user = db.User.First(d => d.IdUser == IdUser);

            if (user.Age > 18)
            {
                return true;
            }

            throw new NotAgeOrderExceptions("Данный товар не может продан данному лицу");
        }

        public bool Payment(int summa)
        {
            if(balance.GetBalance() > summa)
            {
                return true;
            }

            return false;
        }

        public bool Payment()
        {
            throw new NotImplementedException();
        }
    }
}
