using SandwichShop.Interface;

namespace SandwichShop.SandwichAddOns
{
    public class Cheese : SandwichAddOn
    {
        public Cheese(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 0.50;
        }
    }
}