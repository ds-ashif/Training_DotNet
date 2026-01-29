using NUnit.Framework;
// using Assert = NUnit.Framework.Legacy.Assert;


using CalculatorApp.Core;

namespace CalculatorApp.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    public void Add_Positive(){
        Calculator ab=new Calculator();
        int actual= ab.Add(2,3);
        int expected=5;
        // Assert.AreEqual(expected,actual);
        Assert.That(actual, Is.EqualTo(expected));


    }
}
