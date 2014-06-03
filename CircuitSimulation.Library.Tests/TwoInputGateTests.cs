using System;
using CircuitSimulation.Library.Elements;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class TwoInputGateTests
    {
        [Test]
        public void DoesNotGenerateOutputChangedEventAfterInput1DoesNotChangeOutput()
        {
            var element = new TwoInputGateStub();
            element.Input1.Signal = Signal.Off;
            bool eventFired = false;
            element.Output.SignalChanged += () => eventFired = true;
            element.Input1.Signal = Signal.Off;
            Assert.IsFalse(eventFired);
        }

        [Test]
        public void DoesNotGenerateOutputChangedEventAfterInput2DoesNotChangeOutput()
        {
            var element = new TwoInputGateStub();
            element.Input2.Signal = Signal.Off;
            bool eventFired = false;
            element.Output.SignalChanged += () => eventFired = true;
            element.Input2.Signal = Signal.Off;
            Assert.IsFalse(eventFired);
        }

        [Test]
        public void GeneratesOutputChangedEventAfterInput1ChangeChangesOutput()
        {
            var element = new TwoInputGateStub();
            element.Input1.Signal = Signal.Off;
            bool eventFired = false;
            element.Output.SignalChanged += () => eventFired = true;
            element.Input1.Signal = Signal.On;
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void GeneratesOutputChangedEventAfterInput2ChangeChangesOutput()
        {
            var element = new TwoInputGateStub();
            element.Input2.Signal = Signal.Off;
            bool eventFired = false;
            element.Output.SignalChanged += () => eventFired = true;
            element.Input2.Signal = Signal.On;
            Assert.IsTrue(eventFired);
        }
    }

    public class TwoInputGateStub : TwoInputGate
    {
        public TwoInputGateStub()
            : base(0, new ImmediateSimulation())
        {
        }

        protected override void OnInputChanged()
        {
            if (Input1.Signal.IsOn || Input2.Signal.IsOn)
                Output.Signal = Signal.On;
        }

        public override string Description
        {
            get { throw new NotImplementedException(); }
        }
    }
}