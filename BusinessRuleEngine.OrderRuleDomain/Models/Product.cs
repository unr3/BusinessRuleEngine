using BusinessRuleEngine.OrderRuleDomain.Enums;
using System;

namespace BusinessRuleEngine.OrderRuleDomain.Models
{
    public record Product
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public ProductType ProductType { get; init; }
        public Category Category { get; init; }
        public ProductBundle ProductBundle { get; init; }
        public double Price { get; init; }
        public double CommissionRate { get; init; }
    }
}