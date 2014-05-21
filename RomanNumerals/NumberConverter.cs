using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Utils;

namespace RomanNumerals
{
    public class NumberConverter
    {
        private readonly IEnumerable<KeyValuePair<string, int>> _romanWesternArabicPairs = new Dictionary<string, int>
                                                                                               {
                                                                                                   {"I", 1},
                                                                                                   {"V", 5},
                                                                                                   {"X", 10},
                                                                                                   {"L", 50},
                                                                                                   {"C", 100},
                                                                                                   {"D", 500},
                                                                                                   {"M", 1000}
                                                                                               };
        private int _number;

        private NumberConverter(int number)
        {
            _number = number;
        }

        public static string WesternArabicToRoman(int number)
        {
            return new NumberConverter(number).WesternArabicToRoman();
        }

        private string WesternArabicToRoman()
        {
            var romanConversion = new StringBuilder();
            var pairsReversed = _romanWesternArabicPairs.Reverse().ToArray();
            for (int i = 0; i < pairsReversed.Length; i++)
            {
                var romanBuffer = new StringBuilder();
                var romanWesternArabicPair = pairsReversed[i];
                while (_number - romanWesternArabicPair.Value >= 0)
                {
                    _number -= romanWesternArabicPair.Value;
                    romanBuffer.Append(romanWesternArabicPair.Key);
                    if (romanBuffer.Length == 4)
                    {
                        romanBuffer.Remove(0, 3);
                        romanBuffer.Append(pairsReversed[i - 1].Key);
                    }
                }
                if (i + 2 < pairsReversed.Length)
                {
                    if (_number - romanWesternArabicPair.Value + pairsReversed[i + 2].Value >= 0)
                    {
                        _number -= romanWesternArabicPair.Value - pairsReversed[i + 2].Value;
                        romanBuffer.Append(pairsReversed[i + 2].Key);
                        romanBuffer.Append(romanWesternArabicPair.Key);
                    }    
                }
                romanConversion.Append(romanBuffer);
                
            }
            return romanConversion.ToString();
        }
    }
}
