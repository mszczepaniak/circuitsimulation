using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class WireTests
    {
        [Test]
        public void ChangesTargetInputAfterSourceOutputChanged()
        {
            var source = new Output();
            var target = new Input();

            Wire.Connect(source, target);

            source.Signal = Signal.On;

            Assert.AreEqual(Signal.On, target.Signal);
        }
        [Test]
        public void WireConnectReturnCorrectWire()
        {
            var source = new Output();
            var target = new Input();
            var wire = Wire.Connect(source, target);
            Assert.AreEqual(wire.Source,source);
            Assert.AreEqual(wire.Target, target);
        }
    }
}