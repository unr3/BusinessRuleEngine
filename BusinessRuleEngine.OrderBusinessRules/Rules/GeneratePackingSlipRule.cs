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

        
       
        public override Func<Order, bool> Condition => (Order o)=>o.Product.ProductType==ProductType.Physical;

        public override Predicate<Order> Predicate => (Order o)=>_packingSlipService.GeneratePackingSlip(o);

        

        public GeneratePackingSlipRule(IPackingSlipService packingSlipService)
        {
            _packingSlipService = packingSlipService;
        }

        
    }
}