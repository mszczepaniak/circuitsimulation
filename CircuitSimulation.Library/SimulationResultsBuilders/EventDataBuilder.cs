using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public abstract class EventDataBuilder<TEvent, TData> : IEventDataBuilder
        where TData : EventData
        where TEvent : Event
    {
        public EventData BuildEventData(Event evnt)
        {
            if (!(evnt is TEvent))
                throw new SimulationException("Incorrect builder for " + typeof (TEvent));

            return BuildEventData((TEvent) evnt);
        }

        protected abstract TData BuildEventData(TEvent evnt);
    }
}