using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.SimulationResultsBuilders
{
    public class LightChangedBuilder : EventDataBuilder<LightChanged, LightChangedData>
    {
        protected override LightChangedData BuildEventData(LightChanged evnt)
        {
            return new LightChangedData
                       {
                           Time = evnt.Time,
                           DiodeId = evnt.DiodeId,
                           IsLightOn = evnt.IsLightOn,
                           Description = evnt.ToString()
                       };
        }
    }
}