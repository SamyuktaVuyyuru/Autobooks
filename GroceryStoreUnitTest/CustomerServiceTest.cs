using GroceryStore.DataAccess;
using GroceryStore.Models;
using GroceryStore.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GroceryStoreUnitTest
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
    }
}