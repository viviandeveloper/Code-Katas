using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TDDKata1.UnitTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase(new object[] { "" }, Result = 0, TestName = "Add empty string")]
        [TestCase(new object[] { "1" }, Result = 1, TestName = "Add one number")]
        [TestCase(new object[] { "1,2" }, Result = 3, TestName = "Add two numbers")]
        [TestCase(new object[] { "1,2,3,4,5,6" }, Result = 21, TestName = "Add multiple numbers")]
        [TestCase(new object[] { "1\n2,3" }, Result = 6, TestName = "Add separating numbers with new lines")]
        [TestCase(new object[] { "//|\n1|2" }, Result = 3, TestName = "Support different delimiters")]
        public int AddEmptyString(string input)
        {
            return StringCalculator.AddString(input);
        }
    }
}
