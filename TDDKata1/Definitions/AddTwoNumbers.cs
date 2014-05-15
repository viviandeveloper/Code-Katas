using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TDDKata1.Definitions
{
    [Binding]
    public class AddTwoNumbers
    {
        private string _numbers;
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            _numbers = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = StringCalculator.AddString(_numbers);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(3, _result);
        }
    }
}
