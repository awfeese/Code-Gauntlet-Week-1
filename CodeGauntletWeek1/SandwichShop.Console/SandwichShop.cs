using System.Collections.Generic;
using System.Configuration;
using SandwichShop.Interface;
using SandwichShop.SandwichAddOns;
using SandwichShop.SandwichTypes;
using SandwichShop.Sizes;
using SandwichShop.MetroUI;

namespace SandwichShop.Console
{
    using System;

    public class SandwichShop
    {
        private static List<Type> types, addOns, sizes;
        private static Sandwich temp, sandwich;

        public static void Main(string[] args)
        {
            Console.WriteLine("Sandwich Shop");
            
            var typeSelected = PromptForSandwichType();
            temp = Activator.CreateInstance(types[typeSelected-1]) as Sandwich;
            Console.WriteLine();

            var addOnsSelected = PromptForAddOns();
            foreach (int index in addOnsSelected)
            {
                sandwich = Activator.CreateInstance(addOns[index-1], new object[] { temp }) as Sandwich;
                temp = sandwich;
            }
            Console.WriteLine();

            var sizeSelected = PromptForSize();
            sandwich = Activator.CreateInstance(sizes[sizeSelected-1], new object[] { temp }) as Sandwich;
            Console.WriteLine();

            Console.WriteLine("Price: ${0}", string.Format("{0:0.00}", sandwich.Price));
            Console.ReadLine();
        }

        private static int PromptForSandwichType()
        {
            Console.WriteLine("Please select a sandwich type: ");
            types = initializeList("RelativeSandwichTypePath");
            for (int i = 0; i < types.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, types[i].Name);
            }
            var selection = int.Parse(Console.ReadLine());
            return selection;
        }

        private static List<int> PromptForAddOns()
        {
            Console.WriteLine("Please select add-ons separated by a ',': ");
            addOns = initializeList("RelativeAddOnPath");
            for (int i = 0; i < addOns.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, addOns[i].Name);
            }
            var input = Console.ReadLine();
            var inputArray = input.Split(new string[] { "," }, StringSplitOptions.None);

            var selection = new List<int>();
            foreach(string num in inputArray)
            {
                selection.Add(int.Parse(num));
            }
            return selection;
        }
        
        private static int PromptForSize()
        {
            Console.WriteLine("Please select a size: ");
            sizes = initializeList("RelativeSizePath");
            for (int i = 0; i < sizes.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, sizes[i].Name);
            }
            var selection = int.Parse(Console.ReadLine());
            return selection;
        }

        private static List<Type> initializeList(string path)
        {
            List<Type> listOfTypes;

            var typePath = ConfigurationManager.AppSettings[path];
            var applicationPath = AppDomain.CurrentDomain.BaseDirectory;

            if (string.IsNullOrEmpty(typePath))
                typePath = applicationPath;
            else
                typePath = applicationPath + typePath + System.IO.Path.DirectorySeparatorChar;

            listOfTypes = AssemblyLoader.LoadFromAssembly(typePath);
            return listOfTypes;
        }
    }
}