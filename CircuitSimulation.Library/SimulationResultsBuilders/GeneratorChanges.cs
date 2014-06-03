using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class GeneratorChangesBuilder : EventDataBuilder<GeneratorChanges, EventData>
    {
        protected override EventData BuildEventData(GeneratorChanges evnt)
        {
            return new EventData
                {
                    Time = evnt.Time,
                    Description = evnt.ToString()
                };
        }
    }
}