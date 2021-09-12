using System;

namespace BusinessRuleEngine.Test.UnitTest.Rules
{
      public record Order
        {
            public Guid Id { get; init; }
            public Product Product { get; init; }
           
        }
    
}