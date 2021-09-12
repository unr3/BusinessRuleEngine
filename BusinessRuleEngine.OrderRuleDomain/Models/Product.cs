using BusinessRuleEngine.OrderRuleDomain.Enums;
using System;

namespace BusinessRuleEngine.OrderRuleDomain.Models
{
    public record Product
    {
        public Guid Id { get; set; }
        public ProductType ProductType { get; init; }
        public Category Category { get; init; }
    }
}