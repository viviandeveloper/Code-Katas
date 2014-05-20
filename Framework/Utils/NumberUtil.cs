using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Utils
{
    public static class NumberUtil
    {
        public static int[] ToNumberArray(int number)
        {
            return number.ToString()
                .ToCharArray()
                .Select(c => c.ToString())
                .Select(s => Convert.ToInt32(s))
                .ToArray();
        }
    }
}
