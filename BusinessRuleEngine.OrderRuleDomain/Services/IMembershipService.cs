using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderRuleDomain.Services
{
    public interface IMembershipService
    {
        bool ActivateMembership(Guid userId);
    }
}
