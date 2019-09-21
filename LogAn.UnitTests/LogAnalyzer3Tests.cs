using System;
using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    public class LogAnalyzer3Tests
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
        {
            // Arrange
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => throw new Exception("fake exception"));
            
            var analyzer3 = new LogAnalyzer3(stubLogger, mockWebService);
            analyzer3.MinNameLength = 10;
            
            // Act
            analyzer3.Analyze("Short.txt");
            
            // Assert
            mockWebService
                .Received()
                .Write(Arg.Is<ErrorInfo>(info => 
                    info.Severity == 1000 && info.Message.Contains("fake exception")));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare()
        {
            // Arrange
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => throw new Exception("fake exception"));
            
            var analyzer3 = new LogAnalyzer3(stubLogger, mockWebService);
            analyzer3.MinNameLength = 10;
            
            // Act
            analyzer3.Analyze("Short.txt");
            
            // Assert
            var expected = new ErrorInfo(1000, "fake exception");
            mockWebService.Received().Write(expected);
        }
    }
}