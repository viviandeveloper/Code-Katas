using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public class RomanNumeralsConverter
    {
        private readonly uint _number;

        private RomanNumeralsConverter(uint number)
        {
            _number = number;
        }

        public static string Convert(uint number)
        {
            return new RomanNumeralsConverter(number).Convert();
        }

        private string Convert()
        {
            while (_number > 0)
            {
                
            }
            switch (_number)
            {
                case 1:
                    return "I";
                case 5:
                    return "V";
                case 10:
                    return "X";
                case 50:
                    return "L";
                case 100:
                    return "C";
                case 500:
                    return "D";
                case 1000:
                    return "M";
                default:
                    return string.Empty;
            }
        }
    }

    
}
