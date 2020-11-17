using System;
using System.Linq;
using System.Collections.Generic;

/*
 * The Main method is already provided for you in this file 
 * for this project. You MUST NOT change this existing Main method.
 * 
 */

namespace Proj1
{
    class Program1
    {
        //Write a method named "search". The method performs a search 
        //for an element in a list. If the element exists in the list, 
        //the method returns the index of the element in the list. If the 
        //element does not exist in the list, the method returns -1.

        //WRITE CODE FOR THE search METHOD BELOW.
        public static int _myPosition;

        public static int search<T>(List<T> _myItems, T _searchItem) where T : IComparable<T>
        {

            _myPosition = -1;

            foreach (T _myElement in _myItems)
            {
                if (_myElement.CompareTo(_searchItem) == 0)
                {
                    _myPosition = _myItems.IndexOf(_myElement);
                    return _myPosition;

                }

            }
            return _myPosition;
        }


        public static void Main(string[] args)
        {
            //Test-1
            List<int> list1 = new List<int>();
            list1.Add(1); list1.Add(2); list1.Add(3);
            Console.WriteLine("The element exists at index " + search<int>(list1, 3) );

            //Test-2
            Console.WriteLine("The element exists at index " + search<int>(list1, 4));

            //Test-3
            List<double> list2 = new List<double>();
            list2.Add(1.0); list2.Add(2.0); list2.Add(3.0);
            Console.WriteLine("The element exists at index " +  search<double>(list2, 2.0));

            //Test-4
            Console.WriteLine("The element exists at index " + search<double>(list2, 4.0));


            Console.ReadKey(); //halt execution
        }
    }
}

/*
 *  OUTPUT from the above program is given below.
 *
 
The element exists at index 2
The element exists at index -1
The element exists at index 1
The element exists at index -1

 *
 * 
 */
