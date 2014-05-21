using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PancakeFlipper
{
    [TestFixture]
    public class PancakeFlipperTests
    {
        [TestCase(new object[]{new int[0]}, TestName = "Return empty plate when no pancakes", Result = new int[0])]
        [TestCase(new object[]{null}, TestName = "Return empty plate when null", Result = new int[0])]
        public int[] FlipPancakes(int[] unorderedPancakes)
        {
            Debug.WriteLine("Unordered pancakes '{0}'", unorderedPancakes);

            var orderedPancakes = PancakeFlipper.Flip(unorderedPancakes);

            Debug.WriteLine("Ordered pancakes: '{0}'", orderedPancakes);

            return orderedPancakes;
        }
    }
}
