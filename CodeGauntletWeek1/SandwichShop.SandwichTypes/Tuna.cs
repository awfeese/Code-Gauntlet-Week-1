using SandwichShop.Interface;

namespace SandwichShop.SandwichTypes
{
    public class Tuna : Sandwich
    {
        private double price = 4.75;

        public double Price
        {
            get
            {
                return price;
            }
        }
    }
}