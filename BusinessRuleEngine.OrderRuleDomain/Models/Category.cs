using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderRuleDomain.Models
{
    public record Category
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
