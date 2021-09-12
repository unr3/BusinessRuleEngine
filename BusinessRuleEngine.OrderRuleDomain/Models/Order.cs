using System;

namespace BusinessRuleEngine.OrderRuleDomain.Models
{
      public record Order
        {
            public Guid Id { get; init; }
            public Product Product { get; init; }
           
        }
    
}