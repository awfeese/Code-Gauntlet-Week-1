using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using SandwichShop.Interface;
using SandwichShop.SandwichTypes;
using SandwichShop.SandwichAddOns;

namespace SandwichShop.MetroUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string type;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetPrice_Click(object sender, RoutedEventArgs e)
        {
            Type size = getSelectedSize();
            List<Type> addOns = getSelectedAddOns();
            Type sandType = getSelectedSandwich();

            Sandwich prev = Activator.CreateInstance(sandType) as Sandwich;
            Sandwich sandwich;
            foreach ( Type addOn in addOns)
            {
                sandwich = Activator.CreateInstance(addOn, new object[] { prev }) as Sandwich;
                prev = sandwich;
            }          
            sandwich = Activator.CreateInstance(size, new object[] { prev }) as Sandwich;
               
            Price.Content = "Price: $" +  string.Format("{0:0.00}", sandwich.Price);
        }

        private Type getSelectedSize()
        {
            Type size;
            if (SizeRegular.IsChecked.HasValue ? SizeRegular.IsChecked.Value : false)
            {
                size = typeof(Regular);
            }
            else
            {
                size = typeof(Large);
            }
            return size;
        }

        private List<Type> getSelectedAddOns()
        {
            List<Type> addOns = new List<Type>();
            if (AddOnAvocado.IsChecked.HasValue ? AddOnAvocado.IsChecked.Value : false)
            {
                addOns.Add(typeof(Avocado));
            }
            if (AddOnBacon.IsChecked.HasValue ? AddOnBacon.IsChecked.Value : false)
            {
                addOns.Add(typeof(Bacon));
            }
            if (AddOnCheese.IsChecked.HasValue ? AddOnCheese.IsChecked.Value : false)
            {
                addOns.Add(typeof(Cheese));
            }
            if (AddOnSauteedOnions.IsChecked.HasValue ? AddOnSauteedOnions.IsChecked.Value : false)
            {
                addOns.Add(typeof(SauteedOnion));
            }
            return addOns;
        }

        private Type getSelectedSandwich()
        {
            Type type;
            if (TypeTuna.IsSelected)
            {
                type = typeof(Tuna);
            }
            else if (TypeTurkey.IsSelected)
            {
                type = typeof(Turkey);
            }
            else if (TypeVeggie.IsSelected)
            {
                type = typeof(Veggie);
            }
            else
            {
                type = typeof(RoastBeef);
            }
            return type;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            TypeRoastBeef.IsSelected = true;
            AddOnAvocado.IsChecked = false;
            AddOnBacon.IsChecked = false;
            AddOnCheese.IsChecked = false;
            AddOnSauteedOnions.IsChecked = false;
            SizeRegular.IsChecked = true;
            Price.Content = "Price: $0.00";
        }
    }
}
