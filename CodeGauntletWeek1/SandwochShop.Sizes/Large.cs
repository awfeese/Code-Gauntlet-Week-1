using SandwichShop.Interface;
using SandwichShop.SandwichAddOns;

namespace SandwichShop.Sizes
{
    public class Large : SandwichAddOn
    {
        public Large(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 2.50;
        }
    }
}