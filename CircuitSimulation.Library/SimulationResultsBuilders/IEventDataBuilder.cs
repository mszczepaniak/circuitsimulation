using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public interface IEventDataBuilder
    {
        EventData BuildEventData(Event evnt);
    }
}