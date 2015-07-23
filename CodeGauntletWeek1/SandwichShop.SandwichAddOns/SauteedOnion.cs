using SandwichShop.Interface;

namespace SandwichShop.SandwichAddOns
{
    public class SauteedOnion : SandwichAddOn
    {
        public SauteedOnion(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 0.75;
        }
    }
}