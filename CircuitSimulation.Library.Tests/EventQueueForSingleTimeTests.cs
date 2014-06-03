using System;
using CircuitSimulation.Library.Events;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class EventQueueTests
    {
        [Test]
        public void EmptyQueueHasNoEvents()
        {
            var eventQueue = new EventQueue();
            Assert.IsFalse(eventQueue.HasMoreEventsFor(0));
            Assert.IsFalse(eventQueue.HasMoreEventsFor(1));
        }

        [Test]
        public void EventFromQueueIsTheSameAsEventAddedToQueue()
        {
            var eventQueue = new EventQueue();
            var eventStub = new EventStub(0);
            eventQueue.AddEvent(eventStub);
            Assert.AreSame(eventStub, eventQueue.GetNextEventFor(0));
        }

        [Test]
        public void NotEmptyQueueDoesNotHaveEventsAtTheTimeOfEvent()
        {
            var eventQueue = new EventQueue();
            var eventStub = new EventStub(0);
            eventQueue.AddEvent(eventStub);
            Assert.IsFalse(eventQueue.HasMoreEventsFor(1));
        }

        [Test]
        public void NotEmptyQueueHasEventsAtTheTimeOfEvent()
        {
            var eventQueue = new EventQueue();
            var eventStub = new EventStub(0);
            eventQueue.AddEvent(eventStub);
            Assert.IsTrue(eventQueue.HasMoreEventsFor(0));
        }

        [Test]
        public void ReturnsEventsInProperOrder()
        {
            var eventQueue = new EventQueue();
            var eventStub1 = new EventStub(0);
            var eventStub2 = new EventStub(0);

            eventQueue.AddEvent(eventStub1);
            eventQueue.AddEvent(eventStub2);
            Assert.AreSame(eventStub1, eventQueue.GetNextEventFor(0));
            Assert.AreSame(eventStub2, eventQueue.GetNextEventFor(0));
        }

        [Test]
        public void ReturnsNullWhenNoEventWereAddedForGivenTime()
        {
            var eventQueue = new EventQueue();
            Assert.IsNull(eventQueue.GetNextEventFor(0));
        }

        [Test]
        public void ReturnsNullWhenThereIsNoEventForTheGivenTime()
        {
            var eventQueue = new EventQueue();
            var eventStub1 = new EventStub(0);
            eventQueue.AddEvent(eventStub1);
            eventQueue.GetNextEventFor(0);
            Assert.IsNull(eventQueue.GetNextEventFor(0));
        }
    }

    public class EventStub : Event
    {
        public EventStub(int time)
            : base(time)
        {
        }

        public override void Process()
        {
        }

        protected override string Description
        {
            get { throw new NotImplementedException(); }
        }
    }
}