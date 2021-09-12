using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderRuleDomain.Models
{
   public record User
    {
        public Guid Id { get; init; }
        public string Email { get; set; }
        
    }
}
