using BusinessRuleEngine.Abstraction;
using BusinessRuleEngine.OrderRuleDomain.Models;
using BusinessRuleEngine.OrderRuleDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderBusinessRules.Rules
{
   public class LearningToSkiVideoRule:BusinessRule<Order>
    {
        private IPackingSlipService _packingSlipService;

        public LearningToSkiVideoRule(IPackingSlipService packingSlipService)
        {
            if (packingSlipService == null)
                throw new ArgumentNullException($"{nameof(IPackingSlipService)} is empty");

            _packingSlipService = packingSlipService;
        }

        public override Func<Order, bool> Condition => (Order o)=> o.Product.Name== "LearningToSki";

        public override Predicate<Order> Predicate => (Order o)=>_packingSlipService.AddToPackingSlip(o.Product.ProductBundle.Id);
    }
}
