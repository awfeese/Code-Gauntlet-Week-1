using SandwichShop.Interface;
using SandwichShop.SandwichAddOns;
using SandwichShop.SandwichTypes;

namespace SandwichShop.Console
{
    using System;

    public class SandwichShop
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sandwich Shop");

            Sandwich sandwich1 = new Large(new Cheese(new Bacon(new Turkey())));
            Console.WriteLine("Large Cheese, Bacon, and Turkey Sandwich: ${0}",
              string.Format("{0:0.00}", sandwich1.Price));

            Sandwich sandwich2 = new Regular(new Avocado(new SauteedOnion(new Cheese(new RoastBeef()))));
            Console.WriteLine("Regular Avocado, Sautéed Onions, Cheese, and Roast Beef Sandwich: ${0}",
              string.Format("{0:0.00}", sandwich2.Price));

            Console.ReadLine();
        }
    }
}