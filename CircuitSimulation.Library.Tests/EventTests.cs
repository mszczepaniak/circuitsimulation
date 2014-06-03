using System;
using CircuitSimulation.Library.Events;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void InputOfGateChangedAfterEventFired()
        {
            var envt = new EventStub(0);
        }
        class EventStub : Event
        {
            public bool IsProcesed = false;
            public EventStub(int time)
                : base(time)
            {
            }

            public override void Process()
            {
                IsProcesed = true;
            }

            protected override string Description
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}