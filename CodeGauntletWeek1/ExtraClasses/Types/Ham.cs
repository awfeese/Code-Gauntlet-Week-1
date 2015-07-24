using SandwichShop.Interface;

namespace Types
{
    public class Ham : Sandwich
    {
        private double price = 6.00;

        public double Price
        {
            get
            {
                return price;
            }
        }
    }
}
