using System;
using CircuitSimulation.Library.Elements;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class OneInputGateTests
    {
        public class PassThroughGate : OneInputGate
        {
            public PassThroughGate()
                : base(0, new ImmediateSimulation())
            {
            }

            protected override void OnInputChanged()
            {
                Output.Signal = Input.Signal;
            }

            public override string Description
            {
                get { throw new NotImplementedException(); }
            }
        }

        [Test]
        public void DoesNotGenerateOutputChangedEventAfterInputDoesNotChangeOutput()
        {
            var element = new PassThroughGate();
            element.Input.Signal = Signal.Off;
            bool eventFired = false;
            element.Output.SignalChanged += () => eventFired = true;
            element.Input.Signal = Signal.Off;
            Assert.IsFalse(eventFired);
        }

        [Test]
        public void GeneratesOutputChangedEventAfterInputChangeChangesOutput()
        {
            var element = new PassThroughGate();
            element.Input.Signal = Signal.Off;
            bool eventFired = false;
            element.Output.SignalChanged += () => eventFired = true;
            element.Input.Signal = Signal.On;
            Assert.IsTrue(eventFired);
        }
    }
}