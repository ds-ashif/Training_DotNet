using NUnit.Framework;
// using Moq;
using CalculatorApp;
using System;

namespace CalculatorApp.tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_WhenCalled_ReturnsCorrectSum()
        {
            int result = calculator.Add(10,5);
            // Assert.AreEqual(15, result);
            // Assert.That(result,IsEqualTo(15));
           if (result == 15)
                Assert.Pass("Addition successful");
            else
                Assert.Fail("Addition failed");
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsCorrectResult()
        {
            int result = calculator.Subtract(10,3);
            // Assert.AreEqual(7,result);
            // Assert.That(result,IsEqualTo(15));
            if (result == 7)
                Assert.Pass("Subtraction successful");
            else
                Assert.Fail("Subtraction failed");
        }

        [Test]
        public void Multiply_WhenCalled_ReturnsCorrectResult()
        {
            int result = calculator.Multiply(4,5);
            // Assert.AreEqual(20,result);
            // Assert.That(result,IsEqualTo(15));
            if (result == 20)
                Assert.Pass("Multiplication successful");
            else
                Assert.Fail("Multiplication failed");
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            // Assert.Throws<DivideByZeroException>(()=> calculator.Divide(10,0));
            try
            {
                calculator.Divide(10, 0);
                Assert.Fail("Exception expected");
            }
            catch (DivideByZeroException)
            {
                Assert.Pass("Correct exception thrown");
            }
        }
    }
}
