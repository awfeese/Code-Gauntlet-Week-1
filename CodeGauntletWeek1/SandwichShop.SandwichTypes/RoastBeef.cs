namespace SandwichShop.SandwichTypes
{
    public class RoastBeef : SandwichShop.Interface.Sandwich
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