using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PancakeFlipper
{
    public class PancakeFlipper
    {
        private readonly int[] _unorderedPancakes;

        private PancakeFlipper(int[] unorderedPancakes)
        {
            _unorderedPancakes = unorderedPancakes;
        }

        public static int[] Flip(int[] unorderedPancakes)
        {
            return new PancakeFlipper(unorderedPancakes).Flip();
        }

        public int[] Flip()
        {
            if (ArgumentsAreNotValid())
            {
                return new int[0];
            }
            throw new NotImplementedException();
        }

        private bool ArgumentsAreNotValid()
        {
            return _unorderedPancakes == null ||
                   _unorderedPancakes.Length == 0;
        }
    }
}
