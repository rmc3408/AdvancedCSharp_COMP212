using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lab02
{

    

    public class Plant
    {
       
        //public string Fruit { get; set; }
        //public string Vaca { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        

        public Plant(string n, double pr)
        {
            Name = n;
            Price = pr;
            


        }
        public override string ToString()
        {
            return $"{Name} - ${Price}";
        }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Plant> packFruits = new ObservableCollection<Plant>();
        ObservableCollection<Plant> packFlowers = new ObservableCollection<Plant>();
        ObservableCollection<Plant> selectedPlant = new ObservableCollection<Plant>();

        double totalResult;

        public MainWindow()
        {
            InitializeComponent();
            packFruits.Add(new Plant("Plum", 1.30));
            packFruits.Add(new Plant("Kiwi", 3.85));
            this.fruitBox.ItemsSource = packFruits;

            packFlowers.Add(new Plant("Lilly", 9.00));
            packFlowers.Add(new Plant("Rose", 5.50));
            this.flowerBox.ItemsSource = packFlowers;

            //ListCreation();

            this.dataGrid1.ItemsSource = selectedPlant;


            

        }

        private void pickFlower(object sender, SelectionChangedEventArgs e)
        {

            //flowerBox.IsEditable = true;
            //flowerBox.IsReadOnly = true;
            var theFlower = (sender as ComboBox).SelectedItem;
            if (theFlower == null)
            {
                return;
            }
            Plant s = (Plant)theFlower;
            selectedPlant.Add(new Plant(s.Name, s.Price));
            totalResult += s.Price;
            num.Text = totalResult.ToString("C2");
            
        }

        private void pickFruit(object sender, SelectionChangedEventArgs e)
        {
            var theFruit = (sender as ComboBox).SelectedItem;
            if(theFruit == null)
            {
                return;
            }
            Plant s = (Plant)theFruit;
            selectedPlant.Add(new Plant(s.Name, s.Price));
            totalResult += s.Price;
            num.Text = totalResult.ToString("C2");

        }

        private void call_Delete(object sender, RoutedEventArgs e)
        {
                
            Plant vr = (Plant)dataGrid1.SelectedItem;
            if(vr == null) return;
            totalResult -= vr.Price;
            selectedPlant.Remove(vr);
            num.Text = totalResult.ToString("C2");


        }

        private void call_Clear(object sender, RoutedEventArgs e)
        {
            totalResult = 0;
            num.Text = totalResult.ToString("C2");
            flowerBox.Text = "Pick a Flower";
            fruitBox.Text = "Pick a Fruit";
            selectedPlant.Clear();
        }


    }
}
