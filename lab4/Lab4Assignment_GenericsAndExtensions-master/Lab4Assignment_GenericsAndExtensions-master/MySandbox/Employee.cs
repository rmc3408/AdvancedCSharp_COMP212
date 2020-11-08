using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox
{
    public class Employee : Person, IComparable<Employee>
    {
        public Employee(string name, decimal Salary)
        {
            //this.Name = name;
            this.Salary = Salary;
        }

        public Employee() { }

        //public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Salary:C}";
        }

        public int CompareTo(Employee e)
        {
            if (this.Salary < e.Salary) return -1;
            if (this.Salary == e.Salary)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        //public static bool CompareSalary()

    }
}
