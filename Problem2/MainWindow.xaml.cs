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

namespace Problem2
{
    public class MyTestClass
    {
        public string getUpperCase(string a)
        {
            return a.ToUpper();
        }

        public int getLength(string a)
        {
            return a.Length;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ///We need this line to access a method that needs to be
        ///wrapped in a delegate object
        public MyTestClass c = new MyTestClass();

        ////////////////////////////////////////////////////////////////
        //A custom delegate class MyFunc1 has been used. 
        //Provide declaration for that delegate class.
        ////////////////////////////////////////////////////////////////
        //WRITE YOUR CODE BELOW

        public delegate string MyFunc1(string arg);

        ////////////////////////////////////////////////////////////////
        //A custom delegate class MyFunc2 has been used. 
        //Provide declaration for that delegate class.
        ////////////////////////////////////////////////////////////////
        //WRITE YOUR CODE BELOW

        public delegate int MyFunc2(string arg);

        //handler method for click on left button
        private void leftButton_onClick(object sender, RoutedEventArgs e)
        {
            MyFunc1 aDel;

            ///////////////////////////////////////////////////////////////////
            //Wrap the method getUpperCase of MyTestClass in the delegate aDel
            ///////////////////////////////////////////////////////////////////
            //WRITE YOUR CODE BELOW

            aDel = c.getUpperCase;

            //The argument to be passed to the wrapped method is
            //saved in variable theWord.
            string theWord = textbox1.Text;


            string sUpper;
            //////////////////////////////////////////////////////////////
            //Call the method wrapped in aDel (USE Invoke method).
            //Save the returned value from the call in variable sUpper.
            //////////////////////////////////////////////////////////////
            //WRITE YOUR CODE BELOW

            sUpper = aDel.Invoke(theWord);


            //Write the value in sUpper to textBlock
            //WRITE YOUR CODE BELOW
            textblock1.Text = sUpper;
        }

        //handler method for click on right button
        private void rightButton_onClick(object sender, RoutedEventArgs e)
        {
            MyFunc2 bDel;

            ////////////////////////////////////////////////////////////////
            //Wrap the method getLength of MyTestClass in the delegate bDel
            ////////////////////////////////////////////////////////////////
            //WRITE YOUR CODE BELOW

            bDel = c.getLength;
            //The argument to be passed to the wrapped method is
            //saved in variable theWord.
            string theWord = textbox1.Text;

            int sLength;
            //////////////////////////////////////////////////////////////
            //Call the method wrapped in bDel (DO NOT USE Invoke method).
            //Save the returned value from the call in variable sLength. 
            ///////////////////////////////////////////////////////////////
            //WRITE YOUR CODE BELOW

            sLength = bDel.Invoke(theWord);

            ///Write the value in sLength to textBlock
            //WRITE YOUR CODE BELOW
            textblock1.Text = sLength.ToString();
        }
    }

}
