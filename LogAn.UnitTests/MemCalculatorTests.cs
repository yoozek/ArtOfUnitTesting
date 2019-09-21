using NUnit.Framework;

namespace LogAn.UnitTests
{
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            var sut = MakeCalc();

            var sum = sut.Sum();

            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Add_WhenCalled_ChangesSum()
        {
            var sut = MakeCalc();
            sut.Add(1);
            
            var sum = sut.Sum();

            Assert.AreEqual(1, sum);
        }
        
        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}