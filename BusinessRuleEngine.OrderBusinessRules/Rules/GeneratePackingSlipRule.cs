using BusinessRuleEngine.Abstraction;
using BusinessRuleEngine.OrderRuleDomain.Enums;
using BusinessRuleEngine.OrderRuleDomain.Models;
using BusinessRuleEngine.OrderRuleDomain.Services;
using System;

namespace BusinessRuleEngine.OrderBusinessRules.Rules
{
    public class GeneratePackingSlipRule :BusinessRule<Order>
    {
        private IPackingSlipService _packingSlipService;

        public GeneratePackingSlipRule(IPackingSlipService packingSlipService)
        {
            if (packingSlipService == null)
                throw new ArgumentNullException($"{nameof(IPackingSlipService)} is empty");
            _packingSlipService = packingSlipService;
        }

        public override Func<Order, bool> Condition => (Order o)=>o.Product.ProductType==ProductType.Physical;

        public override Predicate<Order> Predicate => (Order o)=>_packingSlipService.GeneratePackingSlip(o);
    }
}