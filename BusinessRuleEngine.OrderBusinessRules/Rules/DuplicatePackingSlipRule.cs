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
    public class DuplicatePackingSlipRule : BusinessRule<Order>
    {
        private IPackingSlipService _packingSlipService;

        public DuplicatePackingSlipRule(IPackingSlipService packingSlipService)
        {
            _packingSlipService = packingSlipService;
        }

        public override Func<Order, bool> Condition => (Order o)=> o.Product.Category.Name=="Book";

        public override Predicate<Order> Predicate => (Order o)=>_packingSlipService.DuplicatePackingSlip(o);
    }
}
