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
using SandwichShop.Sizes;
using System.IO;
using System.Reflection;

namespace SandwichShop.MetroUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        List<Type> sandwichTypes, sandwichAddOns, sandwichSizes;
        Sandwich temp, sandwich;

        public MainWindow()
        {
            InitializeComponent();

            sandwichTypes = initializeList("RelativeSandwichTypePath").OrderBy(x => x.Name).ToList();
            updateUI(sandwichTypes, SandwichTypeListBox);

            sandwichAddOns = initializeList("RelativeAddOnPath").OrderBy(x => x.Name).ToList();
            updateUI(sandwichAddOns, AddOnListBox);

            sandwichSizes = initializeList("RelativeSizePath").OrderBy(x => x.Name).ToList();
            updateUI(sandwichSizes, SizeListBox);

            setSelectedValues();
            addListenerToListBox();
        }


        private List<Type> initializeList(string path)
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

        private void updateUI(List<Type> listOfTypes, ListBox listBox)
        {
            foreach (Type type in listOfTypes)
            {
                listBox.Items.Add(type.Name);
            }
        }
        
        private void setSelectedValues()
        {
            SandwichTypeListBox.SelectedIndex = 0;
            AddOnListBox.SelectedIndex = -1;
            SizeListBox.SelectedIndex = 0;

            updatePrice();
        }

        private void addListenerToListBox()
        {
            SandwichTypeListBox.SelectionChanged += SandwichSelectionChanged;
            AddOnListBox.SelectionChanged += SandwichSelectionChanged;
            SizeListBox.SelectionChanged += SandwichSelectionChanged;
        }
        

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            setSelectedValues();
        }

        private void SandwichSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updatePrice();
        }


        private void updatePrice()
        {
            Type sandwichType = getSelectedSandwich();
            temp = Activator.CreateInstance(sandwichType) as Sandwich;

            List<Type> addOns = getSelectedAddOns();
            foreach (Type addOn in addOns)
            {
                sandwich = Activator.CreateInstance(addOn, new object[] { temp }) as Sandwich;
                temp = sandwich;
            }

            Type size = getSelectedSize();
            sandwich = Activator.CreateInstance(size, new object[] { temp }) as Sandwich;

            Price.Content = "Price: $" + string.Format("{0:0.00}", sandwich.Price);
        }

        private Type getSelectedSandwich()
        {
            Type type = sandwichTypes.Find(x => x.Name == SandwichTypeListBox.SelectedItem.ToString());
            return type;
        }

        private List<Type> getSelectedAddOns()
        {
            var addOns = new List<Type>();
            var selectedItems = AddOnListBox.SelectedItems;

            foreach (object item in selectedItems)
            {
                Type type = sandwichAddOns.Find(x => x.Name == item.ToString());
                addOns.Add(type);
            }

            return addOns;
        }

        private Type getSelectedSize()
        {
            Type type = sandwichSizes.Find(x => x.Name == SizeListBox.SelectedItem.ToString());
            return type;
        }
    }
}
