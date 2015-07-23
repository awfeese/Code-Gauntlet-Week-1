namespace SandwichShop.SandwichTypes
{
    public class Tuna : SandwichShop.Interface.Sandwich
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