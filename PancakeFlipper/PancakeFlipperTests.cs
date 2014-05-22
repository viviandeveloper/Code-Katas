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
        [TestCase(new object[]{new int[0]}, TestName = "Empty plate when no pancakes", Result = new int[0])]
        [TestCase(new object[]{null}, TestName = "Empty plate when null pancakes", Result = new int[0])]
        [TestCase(new object[]{new int[]{1}}, TestName = "Don't flip when 1 pancake", Result = new int[]{1})]
        [TestCase(new object[]{new int[]{1,2,3}}, TestName = "Don't flip ordered pancakes", Result = new int[]{1,2,3})]
        [TestCase(new object[]{new int[]{3,2,1}}, TestName = "Flip unordered pancakes", Result = new int[]{1,2,3})]
        [TestCase(new object[]{new int[]{5,4,5,1,6,2,3,1}}, TestName = "Order many pancakes", Result = new int[]{1,1,2,3,4,5,5,6})]
        public int[] FlipPancakes(int[] unorderedPancakes)
        {
            Debug.WriteLine("Unordered pancakes '{0}'", unorderedPancakes);

            var orderedPancakes = PancakeFlipper.Flip(unorderedPancakes);

            Debug.WriteLine("Ordered pancakes: '{0}'", orderedPancakes);

            return orderedPancakes;
        }
    }
}
