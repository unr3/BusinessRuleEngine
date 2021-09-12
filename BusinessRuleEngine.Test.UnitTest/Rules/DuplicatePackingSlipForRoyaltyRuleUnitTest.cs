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
    public class DuplicatePackingSlipForRoyaltyRuleUnitTest
    {
        [Test]
        public void Should_IsSuccessfulTrue_When_OrderIsBook()
        {
            var order = new Order() { Id=Guid.NewGuid(), Product=new Product() { Id=Guid.NewGuid(), ProductType=ProductType.Physical, Category = new Category() { Id=Guid.NewGuid(),Name="Book" } } };

            var mockPackingSlipService =new  Mock<IPackingSlipService>();
            mockPackingSlipService.Setup(s => s.DuplicatePackingSlip(order)).Returns(true);

            var sut = new DuplicatePackingSlipRule(mockPackingSlipService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
            
        }
    }
}
