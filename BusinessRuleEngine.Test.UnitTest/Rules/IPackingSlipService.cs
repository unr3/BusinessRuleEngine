using System;

namespace BusinessRuleEngine.Test.UnitTest.Rules
{
    public interface IPackingSlipService
    {
        bool GeneratePackingSlip(Order order);
    }
}