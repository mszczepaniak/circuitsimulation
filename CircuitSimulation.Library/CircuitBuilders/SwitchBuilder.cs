using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class SwitchBuilder : ElementBuilder<Switch, SwitchData>
    {
        protected override Switch Build(SwitchData data, Simulation simulation)
        {
            var element = new Switch(data.Delay, simulation);
            element.Id = data.Id;
            element.Output.Id = data.Output.Id;
            element.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal));
            return element;
        }
    }
}