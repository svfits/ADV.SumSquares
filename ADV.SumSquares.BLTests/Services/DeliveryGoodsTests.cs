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
using ADV.SumSquares.BL.Exceptions;

namespace ADV.SumSquares.BL.Services.Tests
{
    [TestClass()]
    public class DeliveryGoodsTests
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

        [TestMethod("Проверка продажи до 18 лет")]
        [ExpectedException(typeof(NotAgeOrderExceptions))]
        public void DeliveryAgeTest()
        {
            //var users = fixture.Create<User>();
            //users.Age = 11;
            var users = fixture.Build<User>().With(f => f.Age, 12).Without(h => h.Age).Create();

            db.User.Add(users);
            db.SaveChanges();

            var mock = new Mock<IBalance>();
            mock.Setup(d => d.GetBalance()).Returns(123);

            var deliveryGoods = new DeliveryGoods(db, mock.Object);
            var delivery = deliveryGoods.DeliveryAge(users.IdUser);

            Assert.IsTrue(delivery);
        }

        [TestMethod("Можно ли продать товар - положительно")]
        public void PaymentTest()
        {
            var mock = new Mock<IBalance>();
            mock.Setup(d => d.GetBalance()).Returns(123);

            var deliveryGoods = new DeliveryGoods(db, mock.Object);
            var pay = deliveryGoods.Payment(34);

            Assert.IsTrue(pay);
        }

        [TestMethod("Можно ли продать товар - отрицательно")]
        public void PaymentTest_Fail()
        {
            var mock = new Mock<IBalance>();
            mock.Setup(d => d.GetBalance()).Returns(12);

            var deliveryGoods = new DeliveryGoods(db, mock.Object);
            var pay = deliveryGoods.Payment(34);

            Assert.IsFalse(pay);
        }
    }
}