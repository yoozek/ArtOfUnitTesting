using LogAn;
using NUnit.Framework;

namespace Tests
{
    public class LogAnalyzerTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            var sut = new LogAnalyzer();

            var result = sut.IsValidLogFileName("test.slf");

            Assert.IsTrue(result);
        }
        
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            var sut = new LogAnalyzer();

            var result = sut.IsValidLogFileName("test.SLF");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            var sut = new LogAnalyzer();

            var result = sut.IsValidLogFileName("test.foo");

            Assert.IsFalse(result);
        }
    }
}