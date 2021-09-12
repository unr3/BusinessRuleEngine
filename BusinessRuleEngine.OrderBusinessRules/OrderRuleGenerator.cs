using BusinessRuleEngine.Abstraction;
using BusinessRuleEngine.OrderBusinessRules.Rules;
using BusinessRuleEngine.OrderRuleDomain.Models;
using BusinessRuleEngine.OrderRuleDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderBusinessRules
{
   public class OrderRuleGenerator:IRuleGenerator<Order>
    {
        private readonly IMembershipService _membershipService;
        private readonly ICommissionService _commissionService;
        private readonly INotificationService _notificationService;
        private readonly IPackingSlipService _packingSlipService;
        public OrderRuleGenerator(IMembershipService membershipService, ICommissionService commissionService, INotificationService notificationService, IPackingSlipService packingSlipService)
        {
            if (membershipService == null)
                throw new ArgumentNullException($"{nameof(IMembershipService)} is empty");
            if (commissionService == null)
                throw new ArgumentNullException($"{nameof(ICommissionService)} is empty");
            if (notificationService == null)
                throw new ArgumentNullException($"{nameof(INotificationService)} is empty");
            if (packingSlipService == null)
                throw new ArgumentNullException($"{nameof(IPackingSlipService)} is empty");

            _membershipService = membershipService;
            _commissionService = commissionService;
            _notificationService = notificationService;
            _packingSlipService = packingSlipService;
        }

        public BusinessRule<Order>[] Generate()
        {
            return new BusinessRule<Order>[] { 
                new GeneratePackingSlipRule(_packingSlipService),
                new DuplicatePackingSlipRule(_packingSlipService),
                new ActivateMembershipRule(_membershipService),
                new UpgradeMembershipRule(_membershipService),
                new GenerateCommissionRule(_commissionService),
                new EmailNotificationForMembershipRule(_notificationService),
                new LearningToSkiVideoRule(_packingSlipService)
            
            };

            /*
             We can use reflection in here. However, There will be a performance issue more than we think because we need to create an instance by using ctor with parameter

                Steps 
                1- find the rules that implements BusinessRule<> abstract class
                2- get ctor(s) from rule class(es)
                3- extract parameter(s) from ctor
                4- create parameter(s)
                5- create rule(s) instance with parameter(s)
             */
        }
    }
}
