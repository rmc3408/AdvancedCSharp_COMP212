using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rishav_Giri_Lab04_Ex03;

namespace QueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueInheritance queue = new QueueInheritance();

            // create objects to store in the queue

            //Double anDouble = 34567;
            string aString = "how";

            // use method Enqueue to add items to queue
            Console.WriteLine("-----Empty Queue-----");
            queue.Display();
            Console.WriteLine();
            Console.WriteLine("-----First Item Queued-----");
            queue.Enqueue("Hey,");
            queue.Display();
            Console.WriteLine("-----Second Item Queued-----");
            queue.Enqueue(aString);
            queue.Display();
            Console.WriteLine("-----Third Item Queued-----");
            queue.Enqueue("you doin'!!");
            queue.Display();

        }
    }
}