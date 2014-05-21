using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RomanNumerals
{
    [TestFixture]
    public class RomanNumeralsTests
    {
        [TestCase(new object[]{0}, TestName = "Convert zero", Result = "")]
        [TestCase(new object[]{1}, TestName = "Convert one", Result = "I")]
        [TestCase(new object[]{5}, TestName = "Convert five", Result = "V")]
        [TestCase(new object[]{10}, TestName = "Convert ten", Result = "X")]
        [TestCase(new object[]{50}, TestName = "Convert fifty", Result = "L")]
        [TestCase(new object[]{100}, TestName = "Convert one hundred", Result = "C")]
        [TestCase(new object[]{500}, TestName = "Convert five hundred", Result = "D")]
        [TestCase(new object[]{1000}, TestName = "Convert one thousand", Result = "M")]
        [TestCase(new object[] { 1732 }, TestName = "Convert 1732", Result = "MDCCXXXII")]
        [TestCase(new object[] { 1956 }, TestName = "Convert 1956", Result = "MCMLVI")]
        public string WesternArabicToRoman(int number)
        {
            Debug.WriteLine(number);

            var result = NumberConverter.WesternArabicToRoman(number);

            Debug.WriteLine(result);

            return result;
        }
    }
}
