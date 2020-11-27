using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataGridComboBoxDatabase
{

    public partial class MainWindow : Window
    {
        private ObservableCollection<Element> fruitDG = new ObservableCollection<Element>();
        private ObservableCollection<Element> planetDG = new ObservableCollection<Element>();

        private List<Element> fruitCB = new List<Element>();
        private List<Element> planetCB = new List<Element>();

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
        }

        public void call_ComboBox_planetPicked(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;
            if (item == null) return;

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
            }
            dataGrid3.ItemsSource = null;
            Func<string> delFruit = () => { fruitComboBox.Text = "Pick a fruit"; return null; };
            Dispatcher.BeginInvoke(delFruit);
            Func<string> delPlanet = () => { planetComboBox.Text = "Pick a planet"; return null; };
            Dispatcher.BeginInvoke(delPlanet);
        }

        public void call_LINQ_Project_QS_Button_Click(object sender, RoutedEventArgs e)
        {
            if (fruitDG.Count != 0 || planetDG.Count != 0)
            {
                using (var context = new FruitDbContext())
                {
                    var query = from f in fruitDG
                                select new { FruitName = f.Name };

                    dataGrid3.ItemsSource = query.ToList();
                }
            }
        }

        public void call_Selected(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                Element selectedItem = (Element)dataGrid1.SelectedItem;
                if (selectedItem == null) return;
                fruitDG.Remove(selectedItem);
                dataGrid1.ItemsSource = fruitDG;

                using (var context = new FruitDbContext())
                {
                    var fruitList = context.FruitDbSet.ToList();
                    foreach (var i in fruitList)
                    {
                        if (selectedItem.elementID == i.elementID)
                        {
                            context.FruitDbSet.Remove(i);
                        }
                    }
                    context.SaveChanges();
                }
            }

            if (dataGrid2.SelectedItem != null)
            {
                Element selectedItem = (Element)dataGrid2.SelectedItem;
                if (selectedItem == null) return;
                planetDG.Remove(selectedItem);
                dataGrid2.ItemsSource = planetDG;

                using (var context = new PlanetDbContext())
                {
                    var planetList = context.PlanetDbSet.ToList();
                    foreach (var p in planetList)
                    {
                        if (selectedItem.elementID == p.elementID)
                        {
                            context.PlanetDbSet.Remove(p);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private void call_Filter(object sender, RoutedEventArgs e)
        {
            if (fruitDG.Count != 0 || planetDG.Count != 0)
            {
                using (var context = new FruitDbContext())
                {
                    var query = from f in context.FruitDbSet
                                where f.Color == "red"
                                select new { FruitName = f.Name };
                    dataGrid3.ItemsSource = query.ToList();
                }
            }
        }

        private void call_OrderBy(object sender, RoutedEventArgs e)
        {
            if (fruitDG.Count != 0 || planetDG.Count != 0)
            {
                using (var context = new FruitDbContext())
                {
                    var query = from f in context.FruitDbSet
                                orderby f.Name
                                select new { FruitName = f.Name };
                    dataGrid3.ItemsSource = query.ToList();
                }
            }
        }

        private void call_InnerJoin(object sender, RoutedEventArgs e)
        {
            if (fruitDG.Count != 0 || planetDG.Count != 0)
            {
                using (var context = new FruitDbContext())
                {
                    var query = from f in fruitDG
                                join p in planetDG
                                on f.Color equals p.Color
                                select new { FruitName = f.Name, PlanetName = p.Name };
                    dataGrid3.ItemsSource = query.ToList();
                }
            }
        }
    }
}