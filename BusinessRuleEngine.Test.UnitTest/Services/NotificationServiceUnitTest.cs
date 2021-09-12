using BusinessRuleEngine.OrderBusinessRules.Services;
using BusinessRuleEngine.OrderRuleDomain.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Test.UnitTest.Services
{
   public class NotificationServiceUnitTest
    {
        INotificationService _sut;

        [SetUp]
        public void Setup()
        {
            /*
             If we want to mock IConfıguration/IConfigurationSection for our services
            
            var mockConfiguration = new Mock<IConfiguration>();
            
            var mockConfigurationSection = new Mock<IConfigurationSection>();

            mockConfigurationSection.Setup(s=>s.Value).Returns("https://emailnotificationproviderurl");

            mockConfiguration.Setup(s=>s.GetSection("sectionname")).Returns(mockConfigurationSection.Object);
            _sut = new EmailNotificationService(mockConfiguration.Object);

             */

            _sut = new EmailNotificationService();
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("  ")]
        public void Should_ThrowError_When_ToIsNullOrWhiteSpace(string to)
        {
            

            Assert.That(()=>_sut.Notify(to),Throws.ArgumentNullException);
        }

        [Test]
        public void Should_ReturnTrue_When_NotificationIsSuccessful()
        {
            string to = "test@email.com";

            bool result = _sut.Notify(to);

            Assert.IsTrue(result);
        }
    }
}
