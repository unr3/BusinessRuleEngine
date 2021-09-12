using BusinessRuleEngine.OrderBusinessRules.Rules;
using BusinessRuleEngine.OrderRuleDomain.Enums;
using BusinessRuleEngine.OrderRuleDomain.Models;
using BusinessRuleEngine.OrderRuleDomain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Test.UnitTest.Rules
{
    public class GenerateCommissionRuleUnitTest
    {
        [Test]
        public void Should_IsSuccessfulTrue_When_OrderIsPhysicalProduct()
        {
            var order = new Order() { Id = Guid.NewGuid(), User = new User() { Id = Guid.NewGuid() }, Product = new Product() { Id = Guid.NewGuid(), ProductType = ProductType.Physical,Price=14.6,CommissionRate=0.12, Category = new Category() { Id = Guid.NewGuid(), Name = "Video" } } };

            var mockCommissionService = new Mock<ICommissionService>();
            mockCommissionService.Setup(s => s.CommissionForAgent(It.IsAny<double>(),It.IsAny<double>())).Returns(true);

            var sut = new GenerateCommissionRule(mockCommissionService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
        }
    }
}
