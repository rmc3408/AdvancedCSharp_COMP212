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
            using (var context = new FruitDbContext())
            {
                bool created = context.Database.CreateIfNotExists();
                var fruitList = context.FruitDbSet.ToList();
                
                foreach (var i in fruitList)
                {
                    fruitDG.Add(i);
                }
            }
            using (var context = new PlanetDbContext())
            {
                bool created = context.Database.CreateIfNotExists();
                var planetList = context.PlanetDbSet.ToList();

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

            using (var context = new FruitDbContext())
            {
                
                context.FruitDbSet.Add(theFruit);
                context.SaveChanges();
            }
         
            using (var context = new FruitDbContext())
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
        
        public void call_ComboBox_planetPicked(object sender, SelectionChangedEventArgs e)
        {

            var item = (sender as ComboBox).SelectedItem;
            if (item == null) return;

            Element v = (Element)item;

            Element thePlanet = new Element();
            thePlanet.Name = ((Element)item).Name;
            thePlanet.Color = ((Element)item).Color;

            using (var context = new PlanetDbContext())
            {

                context.PlanetDbSet.Add(thePlanet);
                context.SaveChanges();
            }

            using (var context = new PlanetDbContext())
            {
                planetDG.Clear();

                var planetList = context.PlanetDbSet.ToList();
                foreach (var i in planetList)
                {
                    planetDG.Add(i);
                }
            }

            Func<string> del = () => { planetComboBox.Text = "Pick a planet"; return null; };
            Dispatcher.BeginInvoke(del);
        }

        
        public void call_Clear(object sender, RoutedEventArgs e)
        {
            
            using (var context = new FruitDbContext())
            {
                var fruitList = context.FruitDbSet.ToList();
                foreach (var i in fruitList)
                {
                    context.FruitDbSet.Remove(i);
                }
                fruitDG.Clear();
                context.SaveChanges();
                dataGrid1.ItemsSource = null;
            }
            using (var context = new PlanetDbContext())
            {
                
                var planetList = context.PlanetDbSet.ToList();

                foreach (var i in planetList)
                {
                    context.PlanetDbSet.Remove(i);
                }
                planetDG.Clear();
                context.SaveChanges();
                dataGrid2.ItemsSource = null;
            }
            dataGrid3.ItemsSource = null;
        }

        
        public void call_LINQ_Project_QS_Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FruitDbContext())
            {
                dataGrid1.ItemsSource = null;
                               
                var query = from f in context.FruitDbSet
                            select new { Name = f.Name};
                              
                dataGrid3.ItemsSource = query.ToList();
            }
        }
        public void call_Selected(object sender, RoutedEventArgs e)
        {
            if(dataGrid1.SelectedItem != null)
            {
                Element selectedItem = (Element)dataGrid1.SelectedItem;
                if (selectedItem == null) return;
                fruitDG.Remove(selectedItem);
            }
            if (dataGrid2.SelectedItem != null)
            {
                Element selectedItem = (Element)dataGrid2.SelectedItem;
                if (selectedItem == null) return;
                planetDG.Remove(selectedItem);
            }

        }

        private void call_Filter(object sender, RoutedEventArgs e)
        {

            using( var context = new FruitDbContext())
            {
               var query = from f in context.FruitDbSet
                           where f.Color == "red"
                           select new { Name = f.Name };
               dataGrid3.ItemsSource = query.ToList();
            }
            
        }
        private void call_OrderBy(object sender, RoutedEventArgs e)
        {
            using (var context = new FruitDbContext())
            {
                var query = from f in context.FruitDbSet
                            select new { Name = f.Name };
                dataGrid3.ItemsSource = query.OrderBy(f => f.Name).ToList();
            }

        }
        private void call_InnerJoin(object sender, RoutedEventArgs e)
        {
            using (var context = new FruitDbContext())
            {
                var query = from f in context.FruitDbSet
                            select new { Name = f.Name };
                dataGrid3.ItemsSource = query.OrderBy(f => f.Name).ToList();
            }

        }
    }
}
