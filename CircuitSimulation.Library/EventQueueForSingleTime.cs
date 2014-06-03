using System.Collections.Generic;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library
{
    internal class EventQueueForSingleTime
    {
        // kolejka zdarzen dla poszczegolnej sekundy
        private readonly Queue<Event> events = new Queue<Event>();

        // proste property sprawdzajace czy mamy jakies zdarzenia w kolejce
        public bool HasEvents
        {
            get { return events.Count != 0; }
        }

        // dodawanie zdarzen
        public void AddEvent(Event evnt)
        {
            events.Enqueue(evnt);
        }

        // zwraca nastepne zdarzenie w kolejce
        public Event GetNextEvent()
        {
            if (!HasEvents) return null;
            return events.Dequeue();
        }
    }
}