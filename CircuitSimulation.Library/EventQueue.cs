using System.Collections.Generic;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library
{
    public class EventQueue
    {
        // slownik kolejki wszystkich zdarzen
        private readonly Dictionary<int, EventQueueForSingleTime> queuesForSingleTime = new Dictionary<int, EventQueueForSingleTime>();

        // dodawanie eventow do slownika
        public void AddEvent(Event evnt)
        {
            if (!queuesForSingleTime.ContainsKey(evnt.Time))
                queuesForSingleTime.Add(evnt.Time, new EventQueueForSingleTime());

            queuesForSingleTime[evnt.Time].AddEvent(evnt);
        }

        // sprawdzanie czy slownik ma jakies eventy dla podanego czasu
        public bool HasMoreEventsFor(int time)
        {
            if (!queuesForSingleTime.ContainsKey(time))
                return false;

            return queuesForSingleTime[time].HasEvents;
        }
        // pobiera nastepne zdarzenie w kolejce dla podanego czasu
        public Event GetNextEventFor(int time)
        {
            // jak nic nie ma to zwroc null
            if (!queuesForSingleTime.ContainsKey(time))
                return null;

            return queuesForSingleTime[time].GetNextEvent();
        }
    }
}