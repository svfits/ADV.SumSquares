using ADV.Model.EF;
using ADV.SumSquares.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV.SumSquares.BL.Services
{
    public class PresentsEmployee
    {
        private readonly DataContextApp db;
        private readonly DateTime dtforPresents;

        /// <summary>
        /// Сервис получения подарков 
        /// </summary>
        /// <param name="db">Контекст БД</param>
        /// <param name="dtforPresents">Дата проверки если сегодня подарки</param>
        public PresentsEmployee(DataContextApp db, DateTime dtforPresents)
        {
            this.db = db;
            this.dtforPresents = dtforPresents;
        }

        public List<User> GetUsersPresents()
        {
            if (dtforPresents == new DateTime(DateTime.Now.Year, 2, 23))
            {
                return db.User.Where(d => d.Sex == Sex.Male).ToList();
            }

            if (dtforPresents == new DateTime(DateTime.Now.Year, 3, 8))
            {
                return db.User.Where(d => d.Sex == Sex.Female).ToList();
            }

            throw new NoHolidayToday("Сегодня нет праздника! Подарков не будет!");
        }
    }
}
