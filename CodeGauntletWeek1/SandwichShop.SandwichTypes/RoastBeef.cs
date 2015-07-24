using SandwichShop.Interface;

namespace SandwichShop.SandwichTypes
{
    public class RoastBeef : Sandwich
    {
        private double price = 5.50;

        public double Price
        {
            get
            {
                return price;
            }
        }
    }
}