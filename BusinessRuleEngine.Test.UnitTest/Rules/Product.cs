using System;

namespace BusinessRuleEngine.Test.UnitTest.Rules
{
    public record Product
    {
        public Guid Id { get; set; }
        public ProductType ProductType { get; init; }
    }
}