using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rishav_Giri_Lab04_Ex01;
using Rishav_Giri_Lab04_Ex02;

namespace StackInheritanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StackInheritance stack = new StackInheritance();
            Double anDouble = 34567;

            Console.WriteLine("-----Empty Stack-----");
            stack.Display();
            // use method Push to add items to stack
            Console.WriteLine("-----Adding first Item----");
            stack.Push(12);
            stack.Display();
            Console.WriteLine("-----Adding Second Item----");
            stack.Push(25);
            stack.Display();
            Console.WriteLine("-----Adding Third Item----");
            stack.Push(anDouble);
            stack.Display();
            Console.WriteLine("-----Adding Fourth Item----");
            stack.Push(35.25);
            stack.Display();
            Console.WriteLine("-----Peeking First Item-----");
            Console.WriteLine("Top item: " + stack.Peek());
            Console.WriteLine();


            // remove items from stack
            try
            {
                while (true)
                {
                    Console.WriteLine("----Removed Item-----");
                    Double removedObject = stack.Pop();
                    Console.WriteLine($"{removedObject} popped");
                    stack.Display();
                }
            }
            catch (EmptyListException emptyListException)
            {
                // if exception occurs, write stack trace
                //Console.Error.WriteLine(emptyListException.StackTrace);
                Console.Error.WriteLine(emptyListException.Message);
            }
        }
    }
}
