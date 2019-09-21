using System;
using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            // Arrange
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => throw new Exception("fake exception"));
            
            var analyzer2 = new LogAnalyzer2(stubLogger, mockWebService);
            analyzer2.MinNameLength = 10;
            var tooShortFileName = "Short.txt";
            
            // Act
            analyzer2.Analyze(tooShortFileName);
            
            // Assert
            mockWebService
                .Received()
                .Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}