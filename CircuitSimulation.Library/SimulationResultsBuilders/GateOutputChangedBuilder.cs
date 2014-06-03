using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class GateOutputChangedBuilder : EventDataBuilder<GateOutputChanged, OutputChangedData>
    {
        protected override OutputChangedData BuildEventData(GateOutputChanged evnt)
        {
            return new OutputChangedData
                {
                    Time = evnt.Time,
                    OutputId = evnt.OutputId,
                    NewSignal = evnt.NewSignal.GetSignalType(),
                    Description = evnt.ToString()
                };
        }
    }
}