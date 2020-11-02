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

namespace Proj1
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

        public string MyFlower
        {
            get { return (string)GetValue(MyFlowerProperty); }
            set { SetValue(MyFlowerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyFlower  .  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyFlowerProperty =
            DependencyProperty.Register("MyFlower", typeof(string), typeof(MyUserControl), new PropertyMetadata(string.Empty));


    }
}
