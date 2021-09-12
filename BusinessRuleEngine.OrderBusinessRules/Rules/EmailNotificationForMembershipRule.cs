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
    public class EmailNotificationForMembershipRule : BusinessRule<Order>
    {
        private INotificationService _notificationService;

        public EmailNotificationForMembershipRule(INotificationService notificationService)
        {
            if (notificationService == null)
                throw new ArgumentNullException($"{nameof(INotificationService)} is empty");
            _notificationService = notificationService;
        }
        public override Func<Order, bool> Condition => (Order o)=> o.Product.Category.Name== "Membership Activation" || o.Product.Category.Name== "Membership Upgrade";

        public override Predicate<Order> Predicate => (Order o)=> _notificationService.Notify(o.User.Email);
    }
}
