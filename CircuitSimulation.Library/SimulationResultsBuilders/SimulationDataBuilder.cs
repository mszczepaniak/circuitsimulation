using System;
using System.Collections.Generic;
using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class SimulationDataBuilder
    {
        private readonly List<Event> processedEvents;
        private readonly Dictionary<Type, IEventDataBuilder> eventDataBuilders = new Dictionary<Type, IEventDataBuilder>();
        public SimulationDataBuilder(List<Event> processedEvents)
        {
            this.processedEvents = processedEvents;

            Register(new DiodeInputChangedBuilder());
            Register(new GateInputChangedBuilder());
            Register(new GateInput1ChangedBuilder());
            Register(new GateInput2ChangedBuilder());
            Register(new GateOutputChangedBuilder());
            Register(new GeneratorOutputChangedBuilder());
            Register(new IntegratedCircuitInputChangedBuilder());
            Register(new IntegratedCircuitOutputChangedBuilder());
            Register(new LightChangedBuilder());
            Register(new GeneratorChangesBuilder());
            Register(new SwitchOutputChangedBuilder());
        }

        public SimulationData BuildResults()
        {
            var results = new List<EventData>();
            foreach (var processedEvent in processedEvents)
            {
                var eventData = BuildEventData(processedEvent);
                results.Add(eventData);
            }

            return new SimulationData {Events = results};
        }

        private EventData BuildEventData(Event evnt)
        {
            var eventType = evnt.GetType();
            if (!eventDataBuilders.ContainsKey(eventType))
                throw new SimulationException("Unknown event " + eventType);
            
            var builder = eventDataBuilders[eventType];
            return builder.BuildEventData(evnt);
        }

        private void Register<TEvent, TData>(EventDataBuilder<TEvent, TData> builder) 
            where TData : EventData
        where TEvent : Event
        {
            eventDataBuilders.Add(typeof(TEvent), builder);
        }
    }
}