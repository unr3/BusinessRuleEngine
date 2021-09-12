using BusinessRuleEngine.OrderRuleDomain.Enums;
using BusinessRuleEngine.OrderRuleDomain.Models;
using BusinessRuleEngine.OrderRuleDomain.Services;


namespace BusinessRuleEngine.OrderBusinessRules.Rules
{
    public class GeneratePackingSlipRule
    {
        private IPackingSlipService _packingSlipService;

        public bool IsSuccessful => _isSuccessful;
        private bool _isSuccessful = false;

        public GeneratePackingSlipRule(IPackingSlipService packingSlipService)
        {
            _packingSlipService = packingSlipService;
        }

        public void Execute(Order order)
        {
            if (order.Product.ProductType == ProductType.Physical)
            {
               _isSuccessful= _packingSlipService.GeneratePackingSlip(order);
            }
        }
    }
}