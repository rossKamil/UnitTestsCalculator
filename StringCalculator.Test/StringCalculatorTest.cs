using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace StringCalculator.Test
{

    public class StringCalculatorTest
    {
        [Test]
        public void ShouldReturnZeroForEmptyString()
        {
            var calc = new StringCalculator();
            var result = calc.Add(string.Empty);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnSameNumberForOneParameter()
        {
            var calc = new StringCalculator();
            var result = calc.Add("1");
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnSumForTwoParameters()
        {
            var calc = new StringCalculator();
            var result = calc.Add("2,5");
            Assert.That(result, Is.EqualTo(7));
        }

        //[Test]
        //public void ShouldThrowExceptionForThreeParameters()
        //{
        //    var calc = new StringCalculator();
        //    //var result = calc.Add("2,5,4");
        //    Assert.That(() => calc.Add("2,6,7"), Throws.TypeOf<ArgumentException>());
        //}

        [Test]
        public void ShouldThrowExceptionWhenContainsInvalidCharacters()
        {
            var calc = new StringCalculator();
            Assert.Multiple(() =>
            {
                Assert.That(() => calc.Add("4,a"), Throws.TypeOf<ArgumentException>());
                Assert.That(() => calc.Add("b,a,c"), Throws.TypeOf<ArgumentException>());
                Assert.That(() => calc.Add("1.2.3"), Throws.TypeOf<ArgumentException>());
            });

        }

        [Test] 
        public void ShouldWorkForMoreParameters([Range(3,100)] int counter)
        {
            var calc = new StringCalculator();

            var tempString = new List<string>();

            for(int i =0; i< counter; i++)
            {
                tempString.Add("1");
            }

            var result = calc.Add(string.Join(',',tempString));
            Assert.That(result, Is.EqualTo(counter));
        }

        [Test]
        public void ShouldAddWhenNewLine()
        {
            var calc = new StringCalculator();
            var result = calc.Add("2\n5");
            Assert.That(result, Is.EqualTo(7));

        }

        [Test]
        public void ShouldAddWhenDiffrentDelimiters()
        {
            var calc = new StringCalculator();
            var result = calc.Add("2\n5,3");
            Assert.That(result, Is.EqualTo(10));

        }

        [Test]
        public void ShouldAddWhenCustomDelimiter()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//;\n1;2");
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ShouldAddWhenCustomWithDefaultDelimiter()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//;\n1;2,3\n4");
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void ShouldThrowExceptionWhenAddNegativeNumbers()
        {
            var calc = new StringCalculator();

            Assert.That(() => calc.Add("-1,2,-3"), Throws.TypeOf<ArgumentException>().With.Message.Contains("-1,-3"));
        }
    }
}
