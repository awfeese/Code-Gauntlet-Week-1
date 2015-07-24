using SandwichShop.Interface;
using SandwichShop.SandwichAddOns;

namespace AddOns
{
    public class Tomato : SandwichAddOn
    {
        public Tomato(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 0.35;
        }
    }
}
