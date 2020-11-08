using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #4 - Using Extensions
/// ** Date (MM/dd/yyy) : 03/26/2020
/// </summary>
namespace Q2_ConsoleAppExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string _myValue = "This is to test whether the extension method count can return a right answer or not";
            Console.WriteLine($"# of stringbuilder length is: {_myValue.CountWords()[0]}");
            Console.WriteLine($"# of words is: {_myValue.CountWords()[1]}");
            Console.ReadKey();
        }
    }
}
