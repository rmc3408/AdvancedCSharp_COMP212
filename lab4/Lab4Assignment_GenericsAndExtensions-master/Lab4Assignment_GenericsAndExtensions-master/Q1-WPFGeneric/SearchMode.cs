using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #4 - Using Generics
/// ** Date (MM/dd/yyy) : 03/26/2020
/// </summary>
namespace Q1_WPFGeneric
{
    public static class SearchMode
    {
        public static int _myPosition;

        // ** Generic search method
        public static int Search<T>(T _searchItem, T[] _myItems) where T : IComparable<T>
        {
            var _resultValue = 0;
            _myPosition = 0;

            foreach(T _myElement in _myItems)
            {
                if (_searchItem.CompareTo(_myElement) == 0)
                {
                    _resultValue = 1;
                    break;
                }
                else
                {
                    _resultValue = -1;
                }

                _myPosition += 1;
            }

            return _resultValue;
        }

        // ** Generic max number method
        public static T MaxNumber<T>(T[] _myItems) where T : IComparable<T>
        {
            var _maxValue = _myItems[0];

            foreach (var _myElement in _myItems)
            {
                if (_myElement.CompareTo(_maxValue) > 0)
                {
                    _maxValue = _myElement;
                }
            }

            return _maxValue;
        }

    }
}
