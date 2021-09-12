using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Test.UnitTest.Rules
{
   public class GeneratePackingSlipForShippingRuleUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Should_IsSuccessfulTrue_When_OrderIsPhysicalProduct()
        {
            var order = new Order() { Id=Guid.NewGuid(), Product= new Product() { 
               Id=Guid.NewGuid(), ProductType = ProductType.Physical } };

            var packingSlipService = new Mock<IPackingSlipService>();
            packingSlipService.Setup(s=>s.GeneratePackingSlip(order)).Returns(true);
            
            var sut = new GeneratePackingSlipRule(packingSlipService.Object);
            sut.Execute(order);

            Assert.IsTrue(sut.IsSuccessful);
        }

       
    }
}
