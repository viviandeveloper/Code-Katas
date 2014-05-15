using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class BowlingScoreTallierTests
    {
        [TestCase(new object[]{""}, Result = 0, TestName = "Tally empty string should return 0")]
        [TestCase(new object[]{"1000000000"}, Result = 1, TestName = "Tally first frame with score")]
        [TestCase(new object[]{"1234567890"}, Result = 45, TestName = "Tally multiple frame scores")]
        [TestCase(new object[]{"X000000000"}, Result = 10, TestName = "Tally strike")]
        [TestCase(new object[]{"/000000000"}, Result = 10, TestName = "Tally spare")]
        [TestCase(new object[]{"X555000000"}, Result = 35, TestName = "Tally strike with scores in consecutive frames")]
        [TestCase(new object[]{"/555000000"}, Result = 30, TestName = "Tally spare with score in consecutive frames")]
        [TestCase(new object[]{"XX5/550000"}, Result = 80, TestName = "Tally frames with several strikes and spares")]
        public int TallyScores(string frames)
        {
            return BowlingScoreTallier.TallyScore(frames);
        }
    }
}
