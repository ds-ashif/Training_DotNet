using NUnit.Framework;
using Moq;
using CollegeService;

namespace CollegeService.Tests
{
    [TestFixture]
    public class CollegeServiceTest
    {
        private Mock<IColegeService> _mockService = null!;

        [SetUp]
        public void Setup()
        {
            // Create mock instance before each test
            _mockService = new Mock<IColegeService>();
        }

        [Test]
        public void GetWelcomeNote_UsingMock_ReturnsMockedValue()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetWelcomeNote("Ali"))
                .Returns("Mock Welcome Ali");

            // Act
            var result = _mockService.Object.GetWelcomeNote("Ali");

            // Assert
            Assert.That(result, Is.EqualTo("Mock Welcome Ali"));
        }

        [Test]
        public void GetFareWellNote_UsingMock_ReturnsMockedValue()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetFareWellNote("Ali"))
                .Returns("Mock Farewell Ali");

            // Act
            var result = _mockService.Object.GetFareWellNote("Ali");

            // Assert
            Assert.That(result, Is.EqualTo("Mock Farewell Ali"));
        }
    }
}
