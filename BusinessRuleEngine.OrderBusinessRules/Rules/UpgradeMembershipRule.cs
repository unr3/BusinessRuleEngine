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
   public class UpgradeMembershipRule:BusinessRule<Order>
    {
        private IMembershipService _membershipService;

        public UpgradeMembershipRule(IMembershipService membershipService)
        {
            if (membershipService == null)
                throw new ArgumentNullException($"{nameof(IMembershipService)} is empty");
            _membershipService = membershipService;
        }

        public override Func<Order, bool> Condition => (Order o) => o.Product.Category.Name == "Membership Upgrade";

        public override Predicate<Order> Predicate => (Order o) => _membershipService.UpgradeMembership(o.User.Id);
    }
}
