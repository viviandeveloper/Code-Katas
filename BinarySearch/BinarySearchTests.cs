using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearch
{
    [TestClass]
    public class BinarySearchTests
    {
        private int _result;
        private int _number;
        private int[] _array;
        private Exception _exception;
        private int _loops;
        private long _timeTaken;
        private long _expectedTime;

        [TestInitialize]
        public void InitialiseTest()
        {
            _array = null;
            _loops = 1000000;
        }

        [TestMethod]
        public void SearchWithEmptyArray()
        {
            GivenNumber(0);
            GivenArrayContainingNumbers();

            WhenIllegalBinarySearchIsPerformed();

            ThenArgumentExceptionShouldBeThrown();
        }

        [TestMethod]
        public void SearchWithNullArray()
        {
            GivenNumber(0);

            WhenIllegalBinarySearchIsPerformed();

            ThenArgumentExceptionShouldBeThrown();
        }

        [TestMethod]
        public void SearchWithArrayNotContainingNumber()
        {
            GivenNumber(0);
            GivenArrayContainingNumbers(1);

            WhenBinarySearchIsPerformed();

            ThenResultShouldBeMinusOne();
        }

        [TestMethod]
        public void SearchWithArrayContainingNumber()
        {
            GivenNumber(1);
            GivenArrayContainingNumbers(1);

            WhenBinarySearchIsPerformed();

            ThenResultShouldBe(0);
        }

        // probaby not a valid test case
        /*[TestMethod]
        public void SearchWithArrayContainingNumbersNotInIncreasingOrder()
        {
            GivenNumber(3);
            GivenArrayContainingNumbers(5, 4, 1, 3, 7);

            WhenIllegalBinarySearchIsPerformed();

            ThenArgumentExceptionShouldBeThrown();
        }*/

        [TestMethod]
        public void SearchWithLargeArrayOfNumbers()
        {
            GivenNumber(32);
            GivenArrayContainingNumbers(13, 19, 24, 29, 32, 37, 43);

            WhenBinarySearchIsPerformed();

            ThenResultShouldBe(4);
        }

        [TestMethod]
        public void SearchWithinEfficientTime()
        {
            GivenNumber(32);
            GivenArrayContainingNumbers(-123, -111, -108, -102, -82, -66, -61 ,-55, -54, -47, -41, -39, -35, -26, -19, -15, -11, -4, 1, 3, 8, 13, 19, 24, 29, 32, 37, 38, 43, 64, 69, 76, 88, 93);
            
            WhenBinarySearchIsPerformedInALoop();

            ThenTimeTakenShouldBeFasterThan();
        }

        #region Given

        private void GivenNumber(int number)
        {
            _number = number;
        }

        private void GivenArrayContainingNumbers(params int[] array)
        {
            _array = array;
        }

        #endregion

        #region When

        private void WhenBinarySearchIsPerformed()
        {
            _result = BinarySearchUtil.Search(_number, _array);
        }

        private void WhenBinarySearchIsPerformedInALoop()
        {
            _loops = _array.Length*40000;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < _loops; i++)
            {
                _result = BinarySearchUtil.Search(_number, _array);
            }
            stopwatch.Stop();
            _timeTaken = stopwatch.ElapsedMilliseconds;
        }

        private void WhenIllegalBinarySearchIsPerformed()
        {
            try
            {
                BinarySearchUtil.Search(_number, _array);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        #endregion

        #region Then

        private void ThenResultShouldBeMinusOne()
        {
            Assert.AreEqual(-1, _result);
        }

        private void ThenResultShouldBe(int expected)
        {
            Assert.AreEqual(expected, _result);
        }

        private void ThenArgumentExceptionShouldBeThrown()
        {
            Assert.AreEqual(typeof(ArgumentException), _exception.GetType());
        }

        private void ThenTimeTakenShouldBeFasterThan()
        {
            Assert.IsTrue(_timeTaken < _loops/(_array.Length*200));
        }

        #endregion
    }
}
