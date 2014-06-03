using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class IntegratedCircuitOutputChangedBuilder : EventDataBuilder<IntegratedCircuitOutputChanged, OutputChangedData>
    {
        protected override OutputChangedData BuildEventData(IntegratedCircuitOutputChanged evnt)
        {
            return new OutputChangedData
                {
                    Time = evnt.Time,
                    Description = evnt.ToString(),
                    OutputId = evnt.OutputId,
                    NewSignal = evnt.NewSignal.GetSignalType()
                };
        }
    }
}