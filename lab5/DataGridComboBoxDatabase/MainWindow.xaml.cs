using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace DataGridComboBoxDatabase
{
    
    public class Vegetable
    {
        
        public int VegetableId { get; set; }
        public string Name  { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return Name + " " + Price;
        }
    }
   


    public partial class MainWindow : Window
    {
        
        ObservableCollection<Vegetable> greenVeggieDG = new ObservableCollection<Vegetable>();
                
        List<Vegetable> greenVeggieCB = new List<Vegetable>();

        public MainWindow()
        {
            InitializeComponent();
            doMyCustomWork();
        }


        public void doMyCustomWork()
        {
            bindTargetControlsToDataSources();
            loadExistingDataFromDatabase();
            prepareComboBoxes();
        }

        public void bindTargetControlsToDataSources()
        {
            //bind the target dataGrid1 to the source greenVeggieDG
            this.dataGrid1.ItemsSource = greenVeggieDG;

            //bind the target comboBox to the source greenVeggieCB
            this.greenComboBox.ItemsSource = greenVeggieCB;
        }

        public void loadExistingDataFromDatabase()
        {
            using (var context = new MyDbContext())
            {
                //Ensure that the database for the context exists. 
                //The database includes the DbSets (in this case the
                //VegetableDbSet only). If the database does not exist 
                //then the database and all its relation schema are created. 
                //When database is created, its "by-convention" name 
                //is the full name of the derived context class
                //(i.e. namespace + class name).
                //For example, in our case the name should be
                //DataGridComboBoxDatabase.MyDbContext
                //Initially, the database tables should be empty. 
                //If the database already exists, no action is taken 
                //and no effort is made to ensure if the database is 
                //compatible with the data model for this context.
                bool created = context.Database.CreateIfNotExists();

                //Get the existing tuples from the VegetableDbSet table (of the 
                //database) as a list of Vegetable objects (or empty list if no 
                //tuple exists) 
                var vegetableList = context.VegetableDbSet.ToList();

                //populate collection greenVeggieDG using the list above
                foreach (var i in vegetableList)
                {
                    greenVeggieDG.Add(i);
                }
            }
        }

        public void prepareComboBoxes()
        {
            greenVeggieCB.Add(new Vegetable { Name = "Cilantro", Price = "5.11" });
            greenVeggieCB.Add(new Vegetable { Name = "Spinach", Price = "10.22" });
            greenVeggieCB.Add(new Vegetable { Name = "Cabbage", Price = "7.33" });
        }


        public void call_ComboBox_greenVegPicked(object sender, SelectionChangedEventArgs e)
        {
            //***** 1. add picked vegetable to database first *********
            //get the item (Vegetable object) selected in greenComboBox
            var item = (sender as ComboBox).SelectedItem;
            if (item == null) return;

            Vegetable v = (Vegetable)item;

            //Item selected in the greenComboBox is a Vegetable object.
            //Create a deep copy of that selected Vegetable object.
            Vegetable theVegetable = new Vegetable();
            theVegetable.Name = ((Vegetable)item).Name;
            theVegetable.Price = ((Vegetable)item).Price;

            using (var context = new MyDbContext())
            {
                //Write the above deep copied Vegetable object to the database
                context.VegetableDbSet.Add(theVegetable);

                //save changes made in the context to the database
                context.SaveChanges();
            }

            //***** 2. Next, refresh datagrid1 with vegetables from database *********
            using (var context = new MyDbContext())
            {
                //empty the collection greenVeggieDG
                //(this will automatically empty the relevant datagrid 
                //as well)
                greenVeggieDG.Clear();


                //get the list of Vegetable objects that are currently
                //present as tuples in the VegetableDbSet table of the database
                var vegetableList = context.VegetableDbSet.ToList();

                //populate the emptied collection greenVeggieDG  
                //using the current Vegetable objects obtained from database
                foreach (var i in vegetableList)
                {
                    greenVeggieDG.Add(i);
                }
            }

            //once a veggie is added to datagrid1, display back 
            //the default text "Pick a green vegetable" in greenComboBox.
            //This has to be done asynchronously using Dispatcher.BeginInvoke,
            //Otherwise, "Pick a green vegetable" won't display back.
            Func<string> del = () => {greenComboBox.Text = "Pick a green vegetable"; return null;};
            Dispatcher.BeginInvoke(del);
        }


        //do projection in LINQ query syntax
        public void call_LINQ_Project_QS_Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                
                dataGrid2.ItemsSource = null;

                
                var query = from v in context.VegetableDbSet
                            select new { VegetableName = v.Name, VegetablePrice = v.Price};
                              
                dataGrid2.ItemsSource = query.ToList();
            }
        }
    }
}
