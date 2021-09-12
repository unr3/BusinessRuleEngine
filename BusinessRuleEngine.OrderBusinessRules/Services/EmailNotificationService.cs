using BusinessRuleEngine.OrderRuleDomain.Services;
using System;

namespace BusinessRuleEngine.OrderBusinessRules.Services
{
    public class EmailNotificationService : INotificationService
    {
        public bool Notify(string to)
        {
            if (string.IsNullOrWhiteSpace(to))
                throw new ArgumentNullException($"{nameof(to)} is empty");
            Console.WriteLine($"Notified {to}");
            return true;
        }
    }
}