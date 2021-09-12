using System;

namespace BusinessRuleEngine.Abstraction
{
    public abstract class BusinessRule<T> where T:class
    {
        public string RuleId => this.GetType().Name;
        
        public bool IsSuccessful => _isSuccessful;
        private bool _isSuccessful = false;

        public bool IsExecuted => _isExecuted;
        private bool _isExecuted = false;

        public bool IsApplied => _isApplied;
        private bool _isApplied = false;
       
        public abstract Func<T, bool> Condition { get; }
        
        public abstract Predicate<T> Predicate { get; }

        public virtual void Execute(T ruleObject)
        {
            _isExecuted = true;
            if (Condition(ruleObject))
            {
                _isApplied = true;
                _isSuccessful = Predicate.Invoke(ruleObject);
            }
        }
    }
}
