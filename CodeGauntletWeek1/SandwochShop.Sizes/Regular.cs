using SandwichShop.Interface;
using SandwichShop.SandwichAddOns;

namespace SandwichShop.Sizes
{
    public class Regular : SandwichAddOn
    {
        public Regular(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 2.00;
        }
    }
}
