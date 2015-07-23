using SandwichShop.Interface;

namespace SandwichShop.SandwichAddOns
{
    public class Bacon : SandwichAddOn
    {
        public Bacon(Sandwich decoratedSandwich)
            : base(decoratedSandwich)
        {
            price = 1.00;
        }
    }
}