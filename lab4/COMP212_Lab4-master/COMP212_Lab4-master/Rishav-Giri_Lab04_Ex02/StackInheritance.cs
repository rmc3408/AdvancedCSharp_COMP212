using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rishav_Giri_Lab04_Ex01;

namespace Rishav_Giri_Lab04_Ex02
{
    public class StackInheritance : List
    {
        // pass name "stack" to List constructor
        public StackInheritance() : base("stack") { }

        // place dataValue at top of stack by inserting 
        // dataValue at front of linked list
        public void Push(Double dataValue)
        {
            InsertAtFront(dataValue);
        }
        // remove item from top of stack by removing
        // item at front of linked list
        public Double Pop()
        {
            return RemoveFromFront();
        }

        public Double Peek()
        {
            if (IsEmpty())
                return 0;
            return lastNode.Data;
        }

    }
}
