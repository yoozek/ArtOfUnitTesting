using System;
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
        
        [TestCase("test.slf", true)]
        [TestCase("test.SLF", true)]
        [TestCase("test.foo", false)]
        [TestCase("test.FOO", false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string fileName, bool expected)
        {
            var sut = new LogAnalyzer();

            var result = sut.IsValidLogFileName(fileName);

            Assert.AreEqual(expected, result);
        }
        

        [TestCase("")]
        [TestCase(null)]
        public void IsValidLogFileName_NullOrEmptyFileName_ThrowsException(string fileName)
        {
            var sut = new LogAnalyzer();

            var ex = Assert.Catch<ArgumentException>(() => { sut.IsValidLogFileName(fileName); });
            
            StringAssert.Contains("filename has to be provided", ex.Message);
        }
        
        [TestCase("badextension.foo", false)]
        [TestCase("goodextension.slf", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            var sut = new LogAnalyzer();

            sut.IsValidLogFileName(fileName);
            
            Assert.AreEqual(expected, sut.WasLastFileNameValid);
        }
    }
}