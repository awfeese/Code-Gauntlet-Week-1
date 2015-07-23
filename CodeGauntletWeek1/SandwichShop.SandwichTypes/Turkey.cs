namespace SandwichShop.SandwichTypes
{
    public class Turkey : SandwichShop.Interface.Sandwich
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