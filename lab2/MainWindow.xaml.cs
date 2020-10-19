using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
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

namespace Bill_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static Dictionary<string, double> flower = new Dictionary<string, double>();
        public static Dictionary<string, double> fruit = new Dictionary<string, double>();
        public static ObservableCollection<OrderItem> order = new ObservableCollection<OrderItem>();
        public const double TAX = 0.13;


        public MainWindow()
        {
            InitializeComponent();
            InitializFlower();
            InitializeFruit();
            InitializeOrder();
        }

        public void InitializFlower()
        {
            flower["Flower"] = 0.00;
            flower["Lily"] = 40.00;
            flower["Rose"] = 30.00;
            Flower.ItemsSource = flower.Keys;
        }

        public void InitializeFruit()
        {
            fruit["Fruit"] = 0.00;
            fruit["Plum"] = 15.00;
            fruit["Kiwi"] = 30.00;

            Appetizer.ItemsSource = fruit.Keys;
        }

        public void InitializeOrder()
        {
            Order.ItemsSource = order;
        }

        private void Beverage_DropDownClosed(object sender, EventArgs e)
        {
            string selectedItem = (string)Flower.SelectedItem;
            if (selectedItem == "Flower")
                return;

            double price = flower[selectedItem];
            OrderItem orderItem = FindOrder(selectedItem, "Flower");

            if (orderItem != null)
            {
                order.Remove(orderItem);
                orderItem.Quantity++;
                order.Add(orderItem);
            }
            else
                order.Add(new OrderItem() { Name = selectedItem, Category = "Flower", Price = price, Quantity = 1 });

            UpdateBill();
        }

        private void Appetizer_DropDownClosed(object sender, EventArgs e)
        {
            string selectedItem = (string)Appetizer.SelectedItem;
            if (selectedItem == "Fruit")
                return;

            double price = fruit[selectedItem];
            OrderItem orderItem = FindOrder(selectedItem, "Fruit");
            if (orderItem != null)
            {
                order.Remove(orderItem);
                orderItem.Quantity++;
                order.Add(orderItem);
            }
            else
                order.Add(new OrderItem() { Name = selectedItem, Category = "Fruit", Price = price, Quantity = 1 });

            UpdateBill();
        }

        public OrderItem FindOrder(string name, string category)
        {
            foreach (OrderItem item in order)
            {
                if (item.Name == name && item.Category == category)
                    return item;
            }
            return null;
        }

        public void UpdateBill()
        {
            double subTotal = 0;
            foreach (OrderItem item in order)
            {
                subTotal += item.Price * item.Quantity;
            }
            double afterTax = subTotal * TAX;

            SubTotal.Content = String.Format("{0:F2}", subTotal); 
            Tax.Content = String.Format("{0:F2}", afterTax);
            Total.Content = String.Format("{0:F2}", subTotal + afterTax);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            order.Clear();
        }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

}
