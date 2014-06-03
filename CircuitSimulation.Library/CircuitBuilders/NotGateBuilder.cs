using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class NotGateBuilder : ElementBuilder<NotGate, NotGateData>
    {
        protected override NotGate Build(NotGateData data, Simulation simulation)
        {
            var gate = new NotGate(data.Delay, simulation);
            gate.Id = data.Id;
            gate.Input.Id = data.Input.Id;
            gate.Input.SetInitialSocketSignal(Signal.FromSignalType(data.Input.Signal));
            gate.Output.Id = data.Output.Id;
            gate.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal));
            return gate;
        }
    }
}