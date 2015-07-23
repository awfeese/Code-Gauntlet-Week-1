using SandwichShop.Interface;

namespace SandwichShop.SandwichAddOns
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