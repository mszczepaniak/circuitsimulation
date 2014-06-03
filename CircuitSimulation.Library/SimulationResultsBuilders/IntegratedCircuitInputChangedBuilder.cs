using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class IntegratedCircuitInputChangedBuilder : EventDataBuilder<IntegratedCircuitInputChanged, InputChangedData>
    {
        protected override InputChangedData BuildEventData(IntegratedCircuitInputChanged evnt)
        {
            return new InputChangedData
                {
                    Time = evnt.Time,
                    Description = evnt.ToString(),
                    InputId = evnt.InputId,
                    NewSignal = evnt.NewSignal.GetSignalType()
                };
        }
    }
}