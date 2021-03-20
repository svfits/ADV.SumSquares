using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADV.SumSquares.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ADV.Model.EF;
using AutoFixture;
using FluentAssertions;
using ADV.SumSquares.BL.Exceptions;

namespace ADV.SumSquares.BL.Services.Tests
{
    [TestClass()]
    public class PresentsEmployeeTests
    {
        private DataContextApp db;
        private Fixture fixture;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<DataContextApp>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            db = new DataContextApp(options);

            fixture = new Fixture();
        }

        [TestMethod("Проверка если подарки на 23 февраля")]
        public async Task GetUsersPresents_23_found()
        {
            var users = fixture.Create<List<User>>();
            db.User.AddRange(users);
            await db.SaveChangesAsync();

            var dt23 = new DateTime(DateTime.Now.Year, 2, 23);

            var presentsEmployee = new PresentsEmployee(db, dt23);
            var userPresents = presentsEmployee.GetUsersPresents();            

            dt23.Should().Equals(userPresents);
        }

        [TestMethod("Проверка если подарки на 8 марта")]
        public async Task GetUsersPresents_8mart_found()
        {
            var users = fixture.Create<List<User>>();
            db.User.AddRange(users);
            await db.SaveChangesAsync();

            var dt8 = new DateTime(DateTime.Now.Year, 3, 8);

            var presentsEmployee = new PresentsEmployee(db, dt8);
            var userPresents = presentsEmployee.GetUsersPresents();

            dt8.Should().Equals(userPresents);
        }

        [TestMethod("Проверка исключения не найдена дата для подарков")]
        [ExpectedException(typeof(NoHolidayToday))]
        public async Task GetUsersPresentsTest()
        {
            var users = fixture.Create<List<User>>();
            db.User.AddRange(users);
            await db.SaveChangesAsync();

            var dtNotPresents = new DateTime(DateTime.Now.Year, 12, 23);

            var presentsEmployee = new PresentsEmployee(db, dtNotPresents);
            presentsEmployee.GetUsersPresents();
        }
    }
}