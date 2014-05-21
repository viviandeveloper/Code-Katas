using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearchUtil
    {
        private readonly int _number;
        private int[] _array;

        private int _largestNumber;
        private int _index;
        private int _length;

        private BinarySearchUtil(int number, int[] array)
        {
            if (array == null ||
                array.Length <= 0)
            {
                throw new ArgumentException("Array argument was not searchable");
            }

            _largestNumber = array[array.Length - 1];
            _number = number;
            _array = array;
            _index = (int)Math.Floor((double)array.Length/2);
            _length = array.Length;
        }

        public static int Search(int number, int[] array)
        {
            return new BinarySearchUtil(number, array).Search();
        }

        private int Search()
        {
            return PerformBinaryChop();
        }

        private int PerformBinaryChop()
        {
            /*if (_array[_index] > _largestNumber)
            {
                throw new ArgumentException("Array not in ascending order");
            }*/

            if (_array[_index] == _number)
            {
                return _index;
            }

            if (NumberIsInLowerSubset())
            {
                _largestNumber = _array[_index];
                _index -= (int) Math.Floor((double) _index/2);
            }
            else
            {
                _index += (int) Math.Floor((double) _index/2);
            }

            HalfLengthOfShadowArray();

            if (NumberNotFound())
            {
                return -1;
            }

            return PerformBinaryChop();
        }

        private bool NumberIsInLowerSubset()
        {
            return _array[_index] > _number;
        }

        private void HalfLengthOfShadowArray()
        {
            _length = (int) Math.Floor((double) _length/2);
        }

        private bool NumberNotFound()
        {
            return _length <= 1;
        }
    }
}
