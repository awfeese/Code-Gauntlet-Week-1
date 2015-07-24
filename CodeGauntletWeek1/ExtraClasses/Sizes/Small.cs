using SandwichShop.Interface;
using SandwichShop.SandwichAddOns;

namespace Sizes
{
    public class Small : SandwichAddOn
    {
        public Small(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 1.50;
        }
    }
}
