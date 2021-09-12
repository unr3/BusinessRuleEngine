using BusinessRuleEngine.OrderRuleDomain.Models;
using System;

namespace BusinessRuleEngine.OrderRuleDomain.Services
{
    public interface IPackingSlipService
    {
        bool GeneratePackingSlip(Order order);

        bool DuplicatePackingSlip(Order order);

        bool AddToPackingSlip(Guid bundleProductId);
    }
}