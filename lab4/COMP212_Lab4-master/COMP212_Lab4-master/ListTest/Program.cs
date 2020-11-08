using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rishav_Giri_Lab04_Ex01;

namespace ListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List(); // create List container

            // create data to store in List

            char aCharacter = 'A';
            Double anDouble = 34567;


            // use List insert methods   
            Console.WriteLine("-----Empty List-----");
            list.Display();
            Console.WriteLine();
            Console.WriteLine("-----Added First Item in List(Front)-----");
            list.InsertAtFront(anDouble);
            list.Display();
            Console.WriteLine("-----Total Items in List (Till now)-----");
            Console.WriteLine($"Number of Elements= {list.Count()}\n");
            Console.WriteLine("-----Added Second Item in List(Front)-----");
            list.InsertAtFront(aCharacter);
            list.Display();
            Console.WriteLine("-----Added First Item in List(Back)-----");
            list.InsertAtBack(22.255);
            list.Display();
            Console.WriteLine("-----Added Second Item in List(Back)-----");
            list.InsertAtBack(1111111);
            list.Display();
            Console.WriteLine("-----Search For Item-----");
            list.Search(1111111);
            Console.WriteLine();
            Console.WriteLine("-----Total Items in List (Till now)-----");
            Console.WriteLine("Number of Elements " + list.Count() + "\n");

            // remove data from list and display after each removal
            try
            {
                Console.WriteLine("-----Removing From Front & Displaying List-----");
                object removedObject = list.RemoveFromFront();
                Console.WriteLine($"{removedObject} removed");
                list.Display();

                Console.WriteLine("-----Removing From Front & Displaying List-----");
                removedObject = list.RemoveFromFront();
                Console.WriteLine($"{removedObject} removed");
                list.Display();

                Console.WriteLine("-----Removing From Back & Displaying List-----");
                removedObject = list.RemoveFromBack();
                Console.WriteLine($"{removedObject} removed");
                list.Display();

                Console.WriteLine("-----Removing From Back & Displaying List-----");
                removedObject = list.RemoveFromBack();
                Console.WriteLine($"{removedObject} removed");
                list.Display();
            }
            catch (EmptyListException emptyListException)
            {
                Console.Error.WriteLine($"\n{emptyListException}");
            }

        }


    }
}