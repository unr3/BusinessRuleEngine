using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.OrderRuleDomain.Services
{
    public interface INotificationService
    {
        bool Notify(string to);
    }
}
