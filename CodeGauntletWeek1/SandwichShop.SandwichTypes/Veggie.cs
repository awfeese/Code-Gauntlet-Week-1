namespace SandwichShop.SandwichTypes
{
    public class Veggie : SandwichShop.Interface.Sandwich
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