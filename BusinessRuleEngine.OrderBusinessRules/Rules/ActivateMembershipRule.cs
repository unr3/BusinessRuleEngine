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
    public class ActivateMembershipRule : BusinessRule<Order>
    {
        private IMembershipService _membershipService;

        public ActivateMembershipRule(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public override Func<Order, bool> Condition => (Order o) => o.Product.Category.Name== "Membership Activation";

        public override Predicate<Order> Predicate => (Order o)=>_membershipService.ActivateMembership(o.User.Id);
    }
}
