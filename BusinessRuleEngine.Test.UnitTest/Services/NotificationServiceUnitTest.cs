using BusinessRuleEngine.OrderRuleDomain.Services;
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
