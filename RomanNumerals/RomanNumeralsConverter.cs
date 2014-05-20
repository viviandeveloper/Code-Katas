using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Utils;

namespace RomanNumerals
{
    public class RomanNumeralsConverter
    {
        private readonly KeyValuePair<string, int>[] _romanNumeralValues;
        private int _number;
        private readonly StringBuilder _output;

        private RomanNumeralsConverter(int number)
        {
            _romanNumeralValues = new Dictionary<string, int>
                                      {
                                          {"I", 1},
                                          {"V", 5},
                                          {"X", 10},
                                          {"L", 50},
                                          {"C", 100},
                                          {"D", 500},
                                          {"M", 1000}
                                      }.Reverse().ToArray();
            _number = number;
            _output = new StringBuilder();
        }

        public static string Convert(int number)
        {
            return new RomanNumeralsConverter(number).Convert();
        }

        private string Convert()
        {
            for (int i = 0; i < _romanNumeralValues.Length; i++)
            {
                var stringBuilder = new StringBuilder();
                while (_number - _romanNumeralValues[i].Value >= 0)
                {
                    _number -= _romanNumeralValues[i].Value;
                    stringBuilder.Append(_romanNumeralValues[i].Key);
                    if (stringBuilder.Length == 4)
                    {
                        stringBuilder.Remove(0, 3);
                        stringBuilder.Append(_romanNumeralValues[i - 1].Key);
                    }
                }
                _output.Append(stringBuilder);
            }
            return _output.ToString();
        }
    }
}
