using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
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


    public class BuiltInDelegateTest
    {
        public static void Main(string[] args)
        {

            ///We need this line to access a method that needs to be
            ///wrapped in a delegate object
            MyTestClass c = new MyTestClass();


            /////////////////////////////////////////////////////////////////////////
            ///Provide declaration for variable aDel using a built-in delegate class 
            ///from Func group.
            /////////////////////////////////////////////////////////////////////////
            //WRITE YOUR CODE BELOW
            Func<string, string> aDel;

            /////////////////////////////////////////////////////////////////////////
            ///Provide declaration for variable bDel using a built-in delegate class 
            ///from Func group.
            /////////////////////////////////////////////////////////////////////////
            //WRITE YOUR CODE BELOW

            Func<string, int> bDel;

            //////////////////////////////
            Console.Write("Enter word: ");
            string s = Console.ReadLine();
            Console.WriteLine("Options:");
            Console.WriteLine("1: Get UpperCase");
            Console.WriteLine("2: Get Length");
            Console.Write("Enter option: ");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    {
                        ////////////////////////////////////////////////////////////////
                        aDel = c.getUpperCase;

                        //The argument to be passed to the wrapped method is
                        //saved in variable theWord.
                        string theWord = s;
                        string sUpper;

                        //////////////////////////////////////////////////////////////
                        //Call the method wrapped in aDel (USE Invoke method).
                        //Save the returned value from the call in variable sUpper.
                        //////////////////////////////////////////////////////////////
                        //WRITE YOUR CODE BELOW

                        sUpper = aDel(s);


                        //Write the value in sUpper to console
                        Console.WriteLine("Uppercase: " + sUpper);
                    }

                    break;
                case 2:
                    {
                        bDel = c.getLength;

                        //The string argument to be passed to the wrapped method is
                        //set in variable theWord.
                        string theWord = s;

                        int sLength;
                        //////////////////////////////////////////////////////////////
                        //Call the method wrapped in bDel (DO NOT USE Invoke method).
                        //Save the returned value from the call in variable sLength. 
                        //////////////////////////////////////////////////////////////
                        //WRITE YOUR CODE BELOW


                        sLength = bDel(s);

                        //Write the value in sLength to console
                        Console.WriteLine("Length: " + sLength);
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");


            Console.ReadKey(); //Halts execution

        }

    }
}
