using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class GateInputChangedBuilder : EventDataBuilder<GateInputChanged, InputChangedData>
    {
        protected override InputChangedData BuildEventData(GateInputChanged evnt)
        {
            return new InputChangedData
                       {
                           Time = evnt.Time, 
                           InputId = evnt.InputId,
                           NewSignal = evnt.NewSignal.GetSignalType(),
                           Description = evnt.ToString()
                       };
        }
    }
}