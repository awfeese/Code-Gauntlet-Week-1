using SandwichShop.Interface;

namespace SandwichShop.SandwichAddOns
{
    public class Regular : SandwichAddOn
    {
        public Regular(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 1.00;
        }
    }
}