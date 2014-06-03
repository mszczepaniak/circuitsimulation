using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class ClockTests
    {
        [Test]
        public void ReturnTrueWhenGivenTimeIsLessThanCurrentTime()
        {
            var clock = new Clock();
            Assert.IsTrue(clock.IsInPast(-1));
        }

        [Test]
        public void TimeIs1AfterFirstMoveNext()
        {
            var clock = new Clock();
            clock.MoveToNext();
            Assert.AreEqual(1, clock.CurrentTime);
        }

        [Test]
        public void IsTime0OnStart()
        {
            var clock = new Clock();
            Assert.AreEqual(0, clock.CurrentTime);
        }
    }
}