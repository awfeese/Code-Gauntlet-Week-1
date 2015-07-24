using SandwichShop.Interface;

namespace SandwichShop.SandwichTypes
{
    public class Veggie : Sandwich
    {
        private double price = 4.00;

        public double Price
        {
            get
            {
                return price;
            }
        }
    }
}