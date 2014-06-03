using CircuitSimulation.Library.Elements;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class NotGateTests
    {
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void TestOutput(int inputSignal, int expectedOutputSignal)
        {
            var notGate = new NotGate(0, new ImmediateSimulation());
            notGate.Input.Signal = Signal.FromInt(inputSignal);
            Assert.AreEqual(Signal.FromInt(expectedOutputSignal), notGate.Output.Signal);
        }
    }
}