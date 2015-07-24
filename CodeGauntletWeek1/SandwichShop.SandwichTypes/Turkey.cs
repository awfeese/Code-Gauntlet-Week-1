using SandwichShop.Interface;

namespace SandwichShop.SandwichTypes
{
    public class Turkey : Sandwich
    {
        private double price = 5.00;

        public double Price
        {
            get
            {
                return price;
            }
        }
    }
}