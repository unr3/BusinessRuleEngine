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
   public class EmailNotificationRuleForMembershipActivationOrUpgradeRuleUnitTest
    {
        [Test]
        public void Should_IsSuccessfulTrue_When_OrderIsMembership()
        {
            var order = new Order() { Id = Guid.NewGuid(), User = new User() { Id = Guid.NewGuid(),Email="test@email.com" }, Product = new Product() { Id = Guid.NewGuid(), ProductType = ProductType.Physical, Category = new Category() { Id = Guid.NewGuid(), Name = "Membership Activation" } } };

            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(s => s.Notify(order.User.Email)).Returns(true);

            var sut = new EmailNotificationForMembershipRule(mockNotificationService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
        }

        [Test]
        public void Should_IsSuccessfulTrue_When_OrderIsMembershipUpgrade()
        {
            var order = new Order() { Id = Guid.NewGuid(), User = new User() { Id = Guid.NewGuid(), Email = "test@email.com" }, Product = new Product() { Id = Guid.NewGuid(), ProductType = ProductType.Physical, Category = new Category() { Id = Guid.NewGuid(), Name = "Membership Upgrade" } } };

            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(s => s.Notify(order.User.Email)).Returns(true);

            var sut = new EmailNotificationForMembershipRule(mockNotificationService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
        }
    }
}
