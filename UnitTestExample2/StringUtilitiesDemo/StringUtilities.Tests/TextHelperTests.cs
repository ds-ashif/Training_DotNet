using NUnit.Framework;
using StringUtilities;

namespace StringUtilities.Tests;

/// <summary>
/// Unit tests for the TextHelper class.
/// </summary>
public class TextHelperTests
{
    private TextHelper _helper;

    /// <summary>
    /// Runs before each test.
    /// Creates a fresh instance to keep tests isolated.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _helper = new TextHelper();
    }

    /// <summary>
    /// Verifies that a valid string is reversed correctly.
    /// </summary>
    [Test]
    public void Reverse_ValidString_ReturnsReversedString()
    {
        // Act
        string result = _helper.Reverse("hello");

        // Assert
        Assert.That(result, Is.EqualTo("olleh"));
    }

    /// <summary>
    /// Verifies that passing null throws ArgumentNullException.
    /// </summary>
    [Test]
    public void Reverse_NullInput_ThrowsArgumentNullException()
    {
        // Assert.Throws executes the lambda and checks the exception type
        Assert.Throws<ArgumentNullException>(
            () => _helper.Reverse(null!)
        );
    }

    /// <summary>
    /// Verifies that passing an empty string throws ArgumentException.
    /// </summary>
    [Test]
    public void Reverse_EmptyString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => _helper.Reverse("")
        );
    }

    /// <summary>
    /// Verifies that the exception contains the correct parameter name.
    /// </summary>
    [Test]
    public void Reverse_NullInput_ExceptionContainsCorrectParamName()
    {
        // Capture the exception so its details can be asserted
        var exception = Assert.Throws<ArgumentNullException>(
            () => _helper.Reverse(null!)
        );

        // Verify the parameter name passed to the exception
        Assert.That(exception.ParamName, Is.EqualTo("text"));
    }
}
