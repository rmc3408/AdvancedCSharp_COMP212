using System;
using System.Collections.Generic;
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
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #4 - Using Generics
/// ** Date (MM/dd/yyy) : 03/26/2020
/// </summary>
namespace Q1_WPFGeneric
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ** Initialize Window
        public MainWindow()
        {
            InitializeComponent();
            this.PrepareComboBox();
        }

        // ** Populate ComboBox
        private void PrepareComboBox()
        {
            this.FromListComboBox.Items.Clear();
            this.FromListComboBox.Items.Add("---");
            for (int i = 1; i <= 2; i++)
            {
                this.FromListComboBox.Items.Add(i);
            }
            this.FromListComboBox.SelectedIndex = 0;
        }

        // ** Declare variable(s)
        private Random _randomNumbers;
        private int _numberOfItems;

        // ** Generate random values (for int and double) button
        private void GenerateValuesButton_Click(object sender, 
            RoutedEventArgs e)
        {
            this.GenerateRandomInt();
            this.GenerateRandomDouble();

            this.PopulateListBox1();
            this.PopulateListBox2();

            MessageBox.Show("Random int and double has been created!");

            // ** Display largest numbers on each
            this.Result1Label.Content = $"Largest int value is : {SearchMode.MaxNumber(MyRandomList.MyList)}";
            this.Result2Label.Content = $"Largest double value is : {SearchMode.MaxNumber(MyRandomList.MyList2)}";
        }

        // ** Generate random int
        private void GenerateRandomInt()
        {
            this._numberOfItems = 999;
            this._randomNumbers = new Random();
            MyRandomList.MyList = new int[10];

            for (int i = 0; i < MyRandomList.MyList.Length; i++)
            {
                int _randomInt = this._randomNumbers.Next(0, this._numberOfItems);
                MyRandomList.MyList[i] = _randomInt;
            }
        }

        // ** Generate random double
        private void GenerateRandomDouble()
        {
            this._randomNumbers = new Random();
            MyRandomList.MyList2 = new double[10];

            for (int i = 0; i < MyRandomList.MyList.Length; i++)
            {
                double _randomDouble = this._randomNumbers.NextDouble();
                if (!MyRandomList.MyList2.Contains(_randomDouble))
                {
                    double _round = 0.00;
                    _round = Math.Round(_randomDouble * 100, 2);
                    MyRandomList.MyList2[i] = _round;
                }
            }
        }

        // ** Populate List Box (for int)
        private void PopulateListBox1()
        {
            this.List1ListBox.Items.Clear();
            int _myPosition = 0;
            foreach (int i in MyRandomList.MyList)
            {
                this.List1ListBox.Items.Add($"{_myPosition++} - {i}");
            }
        }

        // ** Populate List Box (for double)
        private void PopulateListBox2()
        {
            this.List2ListBox.Items.Clear();
            int _myPosition = 0;
            foreach (double i in MyRandomList.MyList2)
            {
                this.List2ListBox.Items.Add($"{_myPosition++} - {i}");
            }
        }

        // ** Clear list button
        private void ClearListButton_Click(object sender, RoutedEventArgs e)
        {
            this.ClearList();
        }

        // ** Clear listbox1, listbox2 and searchItemTextBox
        private void ClearList()
        {
            this.List1ListBox.Items.Clear();
            this.List2ListBox.Items.Clear();
            this.SearchItemTextBox.Clear();
            this.Result1Label.Content = string.Empty;
            this.Result2Label.Content = string.Empty;
            this.FromListComboBox.SelectedIndex = 0;

            MessageBox.Show("All items have been cleared.");
        }

        // ** Search button
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.FromListComboBox.SelectedValue)
            {
                case 1:
                    try
                    {
                        //MyRandomList.mode = "int";
                        int _searchItem = Convert.ToInt32(this.SearchItemTextBox.Text);

                        var _searchResult = SearchMode.Search(_searchItem, MyRandomList.MyList);
                        if (_searchResult == 1)
                        {
                            MessageBox.Show($"{this.SearchItemTextBox.Text} is found on list position {SearchMode._myPosition}");
                            this.List1ListBox.SelectedIndex = SearchMode._myPosition;
                        }
                        else
                        {
                            MessageBox.Show($"{this.SearchItemTextBox.Text} is not on the list.");
                            this.List1ListBox.UnselectAll();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("List 1 is typeof int, please reenter value to be searched.");
                        this.List1ListBox.UnselectAll();
                        this.List2ListBox.UnselectAll();
                    }
                    break;
                case 2:
                    try
                    {
                        //MyRandomList.mode = "double";
                        double _searchItem2 = Convert.ToDouble(this.SearchItemTextBox.Text);

                        var _searchResult2 = SearchMode.Search(_searchItem2, MyRandomList.MyList2);
                        if (_searchResult2 == 1)
                        {
                            MessageBox.Show($"{this.SearchItemTextBox.Text} is found on list position {SearchMode._myPosition}");
                            this.List2ListBox.SelectedIndex = SearchMode._myPosition;
                        }
                        else
                        {
                            MessageBox.Show($"{this.SearchItemTextBox.Text} is not on the list.");
                            this.List1ListBox.UnselectAll();
                            this.List2ListBox.UnselectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("List 2 is typeof double, please reenter value to be searched.");
                        this.List2ListBox.UnselectAll();
                    }


                    break;
                default:
                    MessageBox.Show("Please select from which list to search.");
                    this.FromListComboBox.Focus();
                    return;
            }
        }

    }
}
