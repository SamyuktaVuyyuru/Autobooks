using GroceryStore.DataAccess;
using GroceryStore.Models;
using GroceryStore.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GroceryStore.UnitTest
{
    [TestFixture]
    public class CustomerServiceTest
    {
        List<Customer> customers;

        [SetUp]
        public void Setup()
        {
            customers = new List<Customer>
            {
                new Customer { Id= 1, Name = "test"},
                new Customer { Id= 2, Name = "sam"}
            };
        }

        [Test]
        public void GetAll()
        {
            Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.GetAll()).Returns(customers);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            Assert.AreEqual(2, customerService.GetAll().Count);
        }

        [Test]
        public void GetById()
        {
            Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.GetById(1)).Returns(new Customer { Id = 1, Name = "test" });

            var customerService = new CustomerService(customerRepositoryMock.Object);

            Assert.AreEqual(1, customerService.GetById(1).Id);
            Assert.AreEqual("test", customerService.GetById(1).Name);
        }

        [Test]
        public void Add()
        {
            Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Add("Mark")).Returns(true);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            Assert.IsTrue(customerService.Add("Mark"));
            
        }

        [Test]
        public void Update()
        {
            Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Update(1, "testUpdate")).Returns(true);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            Assert.IsTrue(customerService.Update(1, "testUpdate"));
        }

        [Test]
        public void Delete()
        {
            Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Delete(2)).Returns(true);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            Assert.IsTrue(customerService.Delete(2));
        }
    }
}