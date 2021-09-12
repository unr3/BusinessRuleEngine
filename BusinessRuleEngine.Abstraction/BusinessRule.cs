using System;

namespace BusinessRuleEngine.Abstraction
{
    public abstract class BusinessRule<T> where T:class
    {
        public string RuleId => this.GetType().Name;
        public bool IsSuccessful => _isSuccessful;
        private bool _isSuccessful = false;
        public abstract Func<T, bool> Condition { get; }
        public abstract Predicate<T> Predicate { get; }

        public virtual void Execute(T ruleObject)
        {
            if (Condition(ruleObject))
            {
                _isSuccessful = Predicate.Invoke(ruleObject);
            }
        }
    }
}
