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
   public class LearningToSkiVideoRuleUnitTest
    {
        [Test]
        public void Should_IsSuccessfulTrue_When_VideoIdLearningToSki()
        {
            var order = new Order() { Id = Guid.NewGuid(), User = new User() { Id = Guid.NewGuid() }, Product = new Product() { Id = Guid.NewGuid(), ProductType = ProductType.Physical,Name= "LearningToSki", ProductBundle=new ProductBundle() { Id= Guid.NewGuid(), Name="Free Aid" }, Category = new Category() { Id = Guid.NewGuid(), Name = "Video" } } };

            var mockPackingService = new Mock<IPackingSlipService>();
            mockPackingService.Setup(s => s.AddToPackingSlip(order.Product.ProductBundle.Id)).Returns(true);

            var sut = new LearningToSkiVideoRule(mockPackingService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
        }
    }
}
