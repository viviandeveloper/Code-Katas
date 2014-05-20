using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Utils;
using NUnit.Framework;

namespace Framework.Tests
{
    [TestFixture]
    public class NumberUtilTests
    {
        [Test]
        public void ToNumberArrayCreatesArrayOfNumbers()
        {
            int number = 123;

            int[] result = NumberUtil.ToNumberArray(number);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(new int[]{1,2,3}[0], result[0]);
        }
    }
}
