using System;
using System.Collections.Generic;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library
{
    public class Simulation : ISimulation
    {
        private readonly Clock clock = new Clock();
        private readonly EventQueue eventQueue = new EventQueue();
        private readonly int maxTime;

        private readonly List<Event> processedEvents = new List<Event>();

        public Simulation(int maxTime)
        {
            this.maxTime = maxTime;
        }

        public bool HasStarted { get; private set; }

        public bool ShouldContinue
        {
            get { return clock.CurrentTime <= maxTime; }
        }

        public bool IsRunning
        {
            get { return (HasStarted && ShouldContinue); }
        }

        public int CurrentTime
        {
            get { return clock.CurrentTime; }
        }

        public List<Event> ProcessedEvents
        {
            get { return processedEvents; }
        }

        public void AddEvent(Event evnt)
        {
            if (HasStarted && clock.IsInPast(evnt.Time))
            {
                throw new ArgumentException("Event time cannot be less than current time!");
            }
            eventQueue.AddEvent(evnt);
        }

        public void SimulateNextTimeframe()
        {
            HasStarted = true;
            if (!ShouldContinue)
                throw new SimulationException("Simulation time exceeded max time");

            while (eventQueue.HasMoreEventsFor(clock.CurrentTime))
            {
                var evnt = eventQueue.GetNextEventFor(clock.CurrentTime);
                evnt.Process();
                ProcessedEvents.Add(evnt);
            }

            clock.MoveToNext();
        }
    }
}