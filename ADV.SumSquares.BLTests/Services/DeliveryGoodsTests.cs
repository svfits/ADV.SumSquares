using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADV.SumSquares.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADV.Model.EF;
using Microsoft.EntityFrameworkCore;
using Moq;
using ADV.SumSquares.BL.Interfaces;
using AutoFixture;

namespace ADV.SumSquares.BL.Services.Tests
{
    [TestClass()]
    public class DeliveryGoodsTests
    {
        [TestMethod()]
        public void DeliveryAgeTest()
        {
            var options = new DbContextOptionsBuilder<DataContextApp>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            var db = new DataContextApp(options);

            var fixture = new Fixture();

            var users = fixture.Create<User>();

            db.User.Add(users);
            db.SaveChanges();

            users.IdUser = 11;

            var mock = new Mock<IBalance>();

            mock.Setup(d => d.GetBalance()).Returns(123);

            DeliveryGoods deliveryGoods = new DeliveryGoods(db, mock.Object);
            deliveryGoods.DeliveryAge(users.IdUser);
        }
    }
}