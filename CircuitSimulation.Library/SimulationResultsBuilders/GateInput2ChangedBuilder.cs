using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class GateInput2ChangedBuilder : EventDataBuilder<GateInput2Changed, InputChangedData>
    {
        protected override InputChangedData BuildEventData(GateInput2Changed evnt)
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