using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class DiodeInputChangedBuilder : EventDataBuilder<DiodeInputChanged, InputChangedData>
    {
        protected override InputChangedData BuildEventData(DiodeInputChanged evnt)
        {
            return new InputChangedData
                {
                    Time = evnt.Time,
                    InputId = evnt.InputId,
                    NewSignal = evnt.NewSignal.GetSignalType(),
                    Description = evnt.ToString(),
                };
        }
    }
}