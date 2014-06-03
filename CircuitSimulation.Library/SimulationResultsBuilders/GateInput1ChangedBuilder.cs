using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class GateInput1ChangedBuilder : EventDataBuilder<GateInput1Changed, InputChangedData>
    {
        protected override InputChangedData BuildEventData(GateInput1Changed evnt)
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