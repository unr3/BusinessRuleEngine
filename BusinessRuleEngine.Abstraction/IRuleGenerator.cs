using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Abstraction
{
   public interface IRuleGenerator<T> where T:class
    {
        BusinessRule<T>[] Generate();
    }
}
