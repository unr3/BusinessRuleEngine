using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Abstraction
{
   public interface IRuleEngine<T> where T:class
    {
        IEnumerable<BusinessRule<T>> Rules { get; }
        void Apply(T ruleObject);
    }
}
