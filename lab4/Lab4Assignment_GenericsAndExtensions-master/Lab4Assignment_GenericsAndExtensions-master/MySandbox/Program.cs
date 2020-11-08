using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"{CompareMe(2.2, 1.0, 0.9)}");

            Employee[] employees =
            {
                new Employee("Emp 1", 5000),
                new Employee("Emp 2", 6677),
                new Employee("Emp 3", 2345),
                new Employee("Emp 4", 1000),
                new Employee("Emp 5", 500)
            };

            Console.WriteLine($"{CompareMe(employees[0], employees[1], employees[2])}");
            Console.ReadKey();
        }

        public static T CompareMe<T>(T x, T y, T z) where T : 
            Person, IComparable<T>, new()
        {
            var max = x;

            if (y.CompareTo(max) > 0)
            {
                max = y;
            }

            if (z.CompareTo(max) > 0)
            {
                max = z;
            }

            return max;     
        }
    }
}
