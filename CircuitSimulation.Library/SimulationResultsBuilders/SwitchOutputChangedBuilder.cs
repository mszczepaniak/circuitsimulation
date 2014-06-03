using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class SwitchOutputChangedBuilder : EventDataBuilder<SwitchOutputChanged, OutputChangedData>
    {
        protected override OutputChangedData BuildEventData(SwitchOutputChanged evnt)
        {
            return new OutputChangedData
                {
                    Time = evnt.Time,
                    Description = evnt.ToString(),
                    NewSignal = evnt.NewSignal.GetSignalType(),
                    OutputId = evnt.OutputId
                };
        }
    }
}