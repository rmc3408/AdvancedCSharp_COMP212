using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace DataGridComboBoxDatabase
{
    
    public class Element
    {
        public int elementID { get; set; }
        public string Name  { get; set; }
        public string Color { get; set; }
        

        public override string ToString()
        {
            return Name + " " + Color;
        }
    }
   


    public partial class MainWindow : Window
    {
        
        ObservableCollection<Element> fruitDG = new ObservableCollection<Element>();
        ObservableCollection<Element> planetDG = new ObservableCollection<Element>();

        List<Element> fruitCB = new List<Element>();
        List<Element> planetCB = new List<Element>();

        //ObservableCollection<Element> mixDG = new ObservableCollection<Element>();


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
            
            this.dataGrid1.ItemsSource = fruitDG;
            this.fruitComboBox.ItemsSource = fruitCB;

            this.dataGrid2.ItemsSource = planetDG;
            this.planetComboBox.ItemsSource = planetCB;
        }

        public void loadExistingDataFromDatabase()
        {
            using (var context = new MyDbContext())
            {
                bool created = context.Database.CreateIfNotExists();
                var fruitList = context.FruitDbSet.ToList();
                var planetList = context.PlanetDbSet.ToList();

                foreach (var i in fruitList)
                {
                    fruitDG.Add(i);
                }

                foreach (var i in planetList)
                {
                    planetDG.Add(i);
                }

                
            }
        }

        public void prepareComboBoxes()
        {
            fruitCB.Add(new Element { Name = "kiwi", Color = "red" });
            fruitCB.Add(new Element { Name = "grape", Color = "blue" });
            fruitCB.Add(new Element { Name = "dates", Color = "red" });
            fruitCB.Add(new Element { Name = "pear", Color = "blue" });
            
            planetCB.Add(new Element { Name = "Earth", Color = "red" });
            planetCB.Add(new Element { Name = "Jupiter", Color = "blue" });
        }


        public void call_ComboBox_fruitPicked(object sender, SelectionChangedEventArgs e)
        {
            
            var item = (sender as ComboBox).SelectedItem;
            if (item == null) return;

            Element v = (Element)item;

            Element theFruit = new Element();
            theFruit.Name = ((Element)item).Name;
            theFruit.Color = ((Element)item).Color;

            using (var context = new MyDbContext())
            {
                
                context.FruitDbSet.Add(theFruit);
                context.SaveChanges();
            }
         
            using (var context = new MyDbContext())
            {
                fruitDG.Clear();

                var fruitList = context.FruitDbSet.ToList();
                foreach (var i in fruitList)
                {
                    fruitDG.Add(i);
                }
            }
                        
            Func<string> del = () => { fruitComboBox.Text = "Pick a fruit"; return null;};
            Dispatcher.BeginInvoke(del);
        }
        
        // MUDAR ESSA merda pra PLANET.... FAZER IGUAL a FRUIT.
        public void call_ComboBox_planetPicked(object sender, SelectionChangedEventArgs e)
        {

            var item = (sender as ComboBox).SelectedItem;
            if (item == null) return;

            Element v = (Element)item;

            Element theFruit = new Element();
            theFruit.Name = ((Element)item).Name;
            theFruit.Color = ((Element)item).Color;

            using (var context = new MyDbContext())
            {

                context.FruitDbSet.Add(theFruit);
                context.SaveChanges();
            }

            using (var context = new MyDbContext())
            {
                fruitDG.Clear();

                var fruitList = context.FruitDbSet.ToList();
                foreach (var i in fruitList)
                {
                    fruitDG.Add(i);
                }
            }

            Func<string> del = () => { fruitComboBox.Text = "Pick a fruit"; return null; };
            Dispatcher.BeginInvoke(del);
        }


        //do projection in LINQ query syntax
        public void call_LINQ_Project_QS_Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                
                dataGrid2.ItemsSource = null;

                
                var query = from v in context.FruitDbSet
                            select new { VegetableName = v.Name, VegetablePrice = v.Color};
                              
                dataGrid2.ItemsSource = query.ToList();
            }
        }
    }
}
