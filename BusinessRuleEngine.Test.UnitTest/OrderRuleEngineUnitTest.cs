using BusinessRuleEngine.Abstraction;
using BusinessRuleEngine.OrderRuleDomain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Test.UnitTest
{
    public class OrderRuleEngineUnitTest
    {
        IRuleEngine<Order> _sut;
        Mock<IRuleGenerator<Order>> _mockRuleGenerator;
            

        [SetUp]
        public void Setup()
        {
            _mockRuleGenerator= new Mock<IRuleGenerator<Order>>();
            
        }
        [Test]
        public void Should_ThrowError_When_CalledWithEmptyRuleList()
        {
            var order = new Order();
            BusinessRule<Order>[] rules= null;
            _mockRuleGenerator.Setup(s => s.Generate()).Returns(rules);
            _sut = new OrderRuleEngine(_mockRuleGenerator.Object);

            Assert.That(()=>_sut.Apply(order),Throws.ArgumentNullException);

        }

        [Test]
        public void Should_NotThrowError_When_CalledWithRuleList()
        {
            var order = new Order();
            var mockBusinessRule = new Mock<BusinessRule<Order>>();
            BusinessRule<Order>[] rules = new BusinessRule<Order>[] {mockBusinessRule.Object };
            _mockRuleGenerator.Setup(s => s.Generate()).Returns(rules);
            _sut = new OrderRuleEngine(_mockRuleGenerator.Object);

            Assert.DoesNotThrow(() => _sut.Apply(order));

        }
    }
}
