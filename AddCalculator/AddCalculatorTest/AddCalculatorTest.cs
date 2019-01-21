using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AddCalculatorTest
{
    [TestFixture]
    public class AddCalculatorTest
    {
        AddCalculator objAddCalculator = new AddCalculator();

        [Test]
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("4", 4)]
        public void Test_EmptyStringAndSingleDigit(string numbers, int expected)
        {
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));   
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("4,55,66,77",202)]
        public void Test_MultipleNumbers(string numbers, int expected)
        {
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1\n2,4", 7)]
        [TestCase("1\n2,4\n6,7", 20)] 
        public void Test_NumbersWithMultipleSymbols(string numbers, int expected)
        {
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        [TestCase("//;\n3;5;6", 14)]
        [TestCase("//@\n2@4@7", 13)]
        [TestCase("//@\n2@4,6", 12)]
        public void Test_NumbersWithDifferentDelemeters(string numbers, int expected)
        {
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]       
        [TestCase("1,-2,-3")]
        public void Test_ValidateNumbers(string numbers)
        {
            try
            {
                string[] strSeperator = { ",", "\n"};
                var list = numbers.Split(strSeperator, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
                //Act
                StringCalculator.AddCalculator.ValidateNumbers(list);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("negatives not allowed  -2,-3"));
            }
        }
    }
}
