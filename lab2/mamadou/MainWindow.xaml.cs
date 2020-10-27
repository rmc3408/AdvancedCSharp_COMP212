using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace lab2_Comp212_Fall20
{
    public class DataContent
    {
        public string Name { get; set; }

        public string Price { get; set; }

        private double priceInDouble;


        public DataContent(string name, double price)
        {
            Name = name;
            this.priceInDouble = price;
            Price = string.Format("${0:0.00}", price);
            //Price = price;

        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<DataContent> dataContents = new ObservableCollection<DataContent>();

        double totalPrice = 0;
        public MainWindow()
        {
            InitializeComponent();
            PopulateData();
            
        }

        public void PopulateData()
        {
            this.LabData1.ItemsSource = dataContents;
        }



        private void lilly_Selected(object sender, RoutedEventArgs e)
        {
            dataContents.Add(new DataContent("Lilly", 40.00));
            totalPrice += 40.00;
            textBlock2.Text = totalPrice.ToString("c");
            
        }

        private void rose_Selected(object sender, RoutedEventArgs e)
        {
            dataContents.Add(new DataContent("Rose", 30.00));
            totalPrice += 30.00;
            textBlock2.Text = totalPrice.ToString("c");
        }

        private void plum_Selected(object sender, RoutedEventArgs e)
        {
            dataContents.Add(new DataContent("Plum", 15.00));
            totalPrice += 15.00;
            textBlock2.Text = totalPrice.ToString("c");
        }

        private void kiwi_Selected(object sender, RoutedEventArgs e)
        {
            dataContents.Add(new DataContent("Kiwi", 30.00));
            totalPrice += 30.00;
            textBlock2.Text = totalPrice.ToString("c");
        }

        private void deleteRowButton_Click(object sender, RoutedEventArgs e)
        {
            DataContent d = (DataContent)LabData1.SelectedItem;
            dataContents.Remove(d);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            dataContents.Clear();
            flowerComboBox.SelectedIndex = 0;
            fruitComboBox.SelectedIndex = 0;
            totalPrice = 0;
            textBlock2.Text = "0.00";
        }
    }
}
