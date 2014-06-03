using System;
using CircuitSimulation.Library.Elements;
using CircuitSimulation.Library.Events;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class SimulationTests
    {
        private class EventStub : Event
        {
            public bool IsProcesed;

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

        [Test]
        public void CannotAddEventInThePast()
        {
            var simulation = new Simulation(5);
            Assert.Catch<ArgumentException>(() => new EventStub(-1));
        }

        //eventy nie moga miec czasu wiekszego niz max time
        [Test]
        public void CannotHaveEventsWithTriggerBiggerThanMaxTime()
        {
            var simulation = new Simulation(0);
            var evnt = new EventStub(1);
            simulation.AddEvent(evnt);
            simulation.SimulateNextTimeframe();
            Assert.Catch<SimulationException>(simulation.SimulateNextTimeframe);
        }

        [Test]
        public void DoesNotStartWhenMaxTimeIsNegative()
        {
            var simulation = new Simulation(-1);
            Assert.IsFalse(simulation.ShouldContinue);
        }

        [Test]
        public void ProcessesAddedEvents()
        {
            var simulation = new Simulation(0);
            var evnt = new EventStub(0);
            simulation.AddEvent(evnt);
            simulation.SimulateNextTimeframe();
            Assert.IsTrue(evnt.IsProcesed);
        }

        [Test]
        public void ProcessesAddedEventsInRightOrderForTheSameTime()
        {
            var simulation = new Simulation(1);
            var evnt1 = new EventStub(1);
            var evnt2 = new EventStub(0);
            simulation.AddEvent(evnt1);
            simulation.AddEvent(evnt2);
            simulation.SimulateNextTimeframe();
            Assert.IsTrue(evnt2.IsProcesed);
            Assert.IsFalse(evnt1.IsProcesed);
            simulation.SimulateNextTimeframe();
            Assert.IsTrue(evnt1.IsProcesed);
            Assert.IsTrue(evnt2.IsProcesed);
        }

        [Test]
        public void SimulatesOnlyOneTimeframeWhenMaxTimeIs0()
        {
            var simulation = new Simulation(0);
            Assert.IsTrue(simulation.ShouldContinue);
            simulation.SimulateNextTimeframe();
            Assert.IsFalse(simulation.ShouldContinue);
        }

        //odpalamy caly test
        [Test]
        public void TestRun()
        {
            var simulation = new Simulation(10);
            var andGate = new AndGate(1, simulation);
            var notGate = new NotGate(1, simulation);
            Wire.Connect(andGate.Output, notGate.Input);

            Assert.AreEqual(Signal.Undefined, andGate.Output.Signal);
            Assert.AreEqual(Signal.Undefined, notGate.Output.Signal);

            andGate.Input1.Signal = Signal.On;
            andGate.Input2.Signal = Signal.Off;

            simulation.SimulateNextTimeframe(); // czas 0 - nie ma żadnych zdarzeń do przetworzenia
            simulation.SimulateNextTimeframe(); // czas 1 - zmiany sygnalu przetworzone na bramce and
            simulation.SimulateNextTimeframe(); // czas 2 - zmiana sygnalu przetworzona na bramce not

            Assert.AreEqual(Signal.Off, andGate.Output.Signal);
            Assert.AreEqual(Signal.On, notGate.Output.Signal);

            andGate.Input2.Signal = Signal.On;
            simulation.SimulateNextTimeframe(); // czas 3 - nie ma żadnych zdarzeń do przetworzenia
            simulation.SimulateNextTimeframe(); // czas 4 - zmiana sygnalu przetworzona na bramce and
            simulation.SimulateNextTimeframe(); // czas 5 - zmiana sygnalu przetworzona na bramce not

            Assert.AreEqual(Signal.On, andGate.Output.Signal);
            Assert.AreEqual(Signal.Off, notGate.Output.Signal);
        }

        [Test]
        public void WhenSimulateIsCalledAfterMaxTimeExceptionIsThrown()
        {
            var simulation = new Simulation(0);
            simulation.SimulateNextTimeframe();
            Assert.Catch<SimulationException>(simulation.SimulateNextTimeframe);
        }
    }
}