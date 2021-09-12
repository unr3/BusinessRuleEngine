using BusinessRuleEngine.Abstraction;
using BusinessRuleEngine.OrderRuleDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRuleEngine.OrderBusinessRules
{
    public class OrderRuleEngine : IRuleEngine<Order>
    {
        public IEnumerable<BusinessRule<Order>> Rules => _rules;
        private BusinessRule<Order>[] _rules;
        private readonly IRuleGenerator<Order> _ruleGenerator;
        public OrderRuleEngine(IRuleGenerator<Order> ruleGenerator)
        {
            _ruleGenerator = ruleGenerator;
        }

        public void Apply(Order ruleObject)
        {
            _rules = _ruleGenerator.Generate();
            if (_rules == null || !_rules.Any())
                throw new ArgumentNullException("Rule list can not be empty");

            for (int i = 0; i < _rules.Length; i++)
            {
                _rules[i].Execute(ruleObject);
            }
        }
    }
}