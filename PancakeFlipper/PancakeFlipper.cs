using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PancakeFlipper
{
    public class PancakeFlipper
    {
        private readonly int[] _pancakes;
        private int _largestUnorderedPancakeIndex;
        private int _unorderedPancakesLength;

        private PancakeFlipper(int[] unorderedPancakes)
        {
            _pancakes = unorderedPancakes;
        }

        public static int[] Flip(int[] unorderedPancakes)
        {
            return new PancakeFlipper(unorderedPancakes).Flip();
        }

        public int[] Flip()
        {
            if (NotAStackOfPancakes())
            {
                return new int[0];
            }

            FlipPancakesIntoOrder();

            return _pancakes;
        }

        private bool NotAStackOfPancakes()
        {
            return _pancakes == null ||
                   _pancakes.Length == 0;
        }

        private void FlipPancakesIntoOrder()
        {
            _unorderedPancakesLength = _pancakes.Length;

            while (_unorderedPancakesLength > 0)
            {
                FindLargestUnorderedPancake();

                if (_largestUnorderedPancakeIndex < _unorderedPancakesLength - 1)
                {
                    FlipUnorderedPancakes(_largestUnorderedPancakeIndex + 1);

                    FlipUnorderedPancakes(_unorderedPancakesLength);
                }
                
                _unorderedPancakesLength--;
            }
        }

        private void FindLargestUnorderedPancake()
        {
            var largestPancakeSize = 0;
            for (int i = _unorderedPancakesLength - 1; i >= 0; i--)
            {
                if (_pancakes[i] > largestPancakeSize)
                {
                    largestPancakeSize = _pancakes[i];
                    _largestUnorderedPancakeIndex = i;
                }
            }
        }

        private void FlipUnorderedPancakes(int numberOfPancakesToFlip)
        {
            var tempPancakes = _pancakes.Take(numberOfPancakesToFlip)
                .Reverse()
                .ToArray();
            for (int i = 0; i < tempPancakes.Length; i++)
            {
                _pancakes[i] = tempPancakes[i];
            }
        }
    }
}
