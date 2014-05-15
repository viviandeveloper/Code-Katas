using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TDDKata1
{
    public class StringCalculator
    {
        private readonly string _input;
        private readonly string[] _defaultDelimiters = new string[] {",", "\n"};
        private readonly string[] _delimiters;
        private readonly Regex _delimiterRegex = new Regex(@"^//(.)\n(.+)$");
        private readonly Regex _inputRegex = new Regex(@"(^//.\\n)?(.+)");

        private StringCalculator(string input)
        {
            _input = _inputRegex.Match(input).Groups[2].Value;
            var delimiter = _delimiterRegex.Match(input).Groups[1].Value;
            if (string.IsNullOrEmpty(delimiter))
            {
                _delimiters = _defaultDelimiters;
            }
            else
            {
                _delimiters = new string[]{delimiter};
            }
        }

        public static int AddString(string input)
        {
            return new StringCalculator(input).Add();
        }

        protected virtual int Add()
        {
            if (string.IsNullOrEmpty(_input))
            {
                return 0;
            }

            var numbers = GetNumbers();

            var result = numbers.Aggregate((aggregate, accumulate) => aggregate += accumulate);

            return result;
        }

        private int[] GetNumbers()
        {
            string[] stringNumbers = SplitStringNumbers();
            int[] numbers = new int[stringNumbers.Length];

            for (int i = 0; i < stringNumbers.Length; i++)
            {
                numbers[i] = Convert.ToInt16(stringNumbers[i]);
            }

            return numbers;
        }

        private string[] SplitStringNumbers()
        {
            return _input.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
