using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class GeneratorOutputChangedBuilder : EventDataBuilder<GeneratorOutputChanged, OutputChangedData>
    {
        protected override OutputChangedData BuildEventData(GeneratorOutputChanged evnt)
        {
            return new OutputChangedData
                       {
                           OutputId = evnt.OutputId,
                           NewSignal = evnt.NewSignal.GetSignalType(),
                           Time = evnt.Time,
                           Description = evnt.ToString()
                       };
        }
    }
}