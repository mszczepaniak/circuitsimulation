using CircuitSimulation.Library.Elements;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class FlipFlopTests
    {
        [Test]
        public void Test()
        {
            var flipFlop = new FlipFlop(0, new ImmediateSimulation());

            flipFlop.SetInput.Signal = Signal.On;
            Assert.AreEqual(Signal.On, flipFlop.Output.Signal);
            Assert.AreEqual(Signal.Off, flipFlop.NegativeOutput.Signal);

            flipFlop.SetInput.Signal = Signal.Off;
            Assert.AreEqual(Signal.On, flipFlop.Output.Signal);
            Assert.AreEqual(Signal.Off, flipFlop.NegativeOutput.Signal);

            flipFlop.ResetInput.Signal = Signal.On;
            Assert.AreEqual(Signal.Off, flipFlop.Output.Signal);
            Assert.AreEqual(Signal.On, flipFlop.NegativeOutput.Signal);

            flipFlop.ResetInput.Signal = Signal.Off;
            Assert.AreEqual(Signal.Off, flipFlop.Output.Signal);
            Assert.AreEqual(Signal.On, flipFlop.NegativeOutput.Signal);
        }
    }
}