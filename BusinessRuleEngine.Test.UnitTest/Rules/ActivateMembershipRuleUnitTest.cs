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
   public class ActivateMembershipRuleUnitTest
    {
        [Test]
        public void Should_IsSuccessfulTrue_When_OrderIsMembership()
        {
            var order = new Order() { Id = Guid.NewGuid(),User=new User() { Id=Guid.NewGuid() }, Product = new Product() { Id = Guid.NewGuid(), ProductType = ProductType.Physical, Category = new Category() { Id = Guid.NewGuid(), Name = "Membership Activation" } } };

            var mockMembershipService = new Mock<IMembershipService>();
            mockMembershipService.Setup(s=>s.ActivateMembership(It.IsAny<Guid>())).Returns(true);

            var sut = new ActivateMembershipRule(mockMembershipService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
        }
    }
}
