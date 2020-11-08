using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2_ConsoleAppExtensions
{
    public static class StringExtension
    {
        public static List<int> CountWords(this string stringParameter)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            int _totalWords = 0;
            int _totalWords2 = 0;

            string[] _wordings = stringParameter.Split(' ');

            foreach (string _word in _wordings)
            {
                _stringBuilder.Append(_word);
                _totalWords2 += 1;
            }

            _totalWords = _stringBuilder.Length;
            List<int> _results = new List<int>
            {
                _totalWords, _totalWords2
            };

            return _results;
        }
    }
}
