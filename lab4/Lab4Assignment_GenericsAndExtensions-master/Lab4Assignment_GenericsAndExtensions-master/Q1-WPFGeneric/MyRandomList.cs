using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1_WPFGeneric
{
    public class MyRandomList : IComparable<MyRandomList>
    {
        public static int[] MyList;
        public static double[] MyList2;

        private int MyNumber { get; set; }
        private double MyNumber2 { get; set; }

        public static string mode;

        public MyRandomList(int myNumber)
        {
            this.MyNumber = myNumber;
        }

        public MyRandomList(double myNumber)
        {
            this.MyNumber2 = myNumber;
        }

        public MyRandomList() { }

        public override string ToString()
        {
            string _returnString = string.Empty;

            switch (mode)
            {
                case "int":
                    _returnString = $"{MyNumber}";
                    break;
                case "double":
                    _returnString = $"{MyNumber2}";
                    break;
            }

            return _returnString;
        }

        public int CompareTo(MyRandomList m)
        {
            int _returnValue = 0;

            switch (mode)
            {
                case "int":
                    if (this.MyNumber < m.MyNumber)
                    {
                        _returnValue = -1;
                    }
                    if (this.MyNumber == m.MyNumber)
                    {
                        _returnValue = 0;
                    }
                    else
                    {
                        _returnValue = 1;
                    }
                    break;

                case "double":
                    if (this.MyNumber2 < m.MyNumber2)
                    {
                        _returnValue = -1;
                    }
                    if (this.MyNumber2 == m.MyNumber2)
                    {
                        _returnValue = 0;
                    }
                    else
                    {
                        _returnValue = 1;
                    }
                    break;
            }

            return _returnValue;
        }

    }
}
