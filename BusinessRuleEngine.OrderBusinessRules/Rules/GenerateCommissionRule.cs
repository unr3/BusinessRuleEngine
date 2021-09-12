using BusinessRuleEngine.Abstraction;
using BusinessRuleEngine.OrderRuleDomain.Enums;
using BusinessRuleEngine.OrderRuleDomain.Models;
using BusinessRuleEngine.OrderRuleDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderBusinessRules.Rules
{
   public class GenerateCommissionRule:BusinessRule<Order>
    {
        private ICommissionService _commissionService;

        public GenerateCommissionRule(ICommissionService commissionService)
        {
            _commissionService = commissionService;
        }

        public override Func<Order, bool> Condition => (Order o) => o.Product.ProductType==ProductType.Physical || o.Product.Category.Name=="Book";

        public override Predicate<Order> Predicate => (Order o)=>_commissionService.CommissionForAgent(o.Product.Price,o.Product.CommissionRate);
    }
}
