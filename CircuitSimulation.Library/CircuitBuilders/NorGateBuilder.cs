using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class NorGateBuilder : ElementBuilder<NorGate, NorGateData>
    {
        protected override NorGate Build(NorGateData data, Simulation simulation)
        {
            var gate = new NorGate(data.Delay, simulation);
            gate.Id = data.Id;
            gate.Input1.Id = data.Input1.Id;
            gate.Input1.SetInitialSocketSignal(Signal.FromSignalType(data.Input1.Signal));
            gate.Input2.Id = data.Input2.Id;
            gate.Input2.SetInitialSocketSignal(Signal.FromSignalType(data.Input2.Signal));
            gate.Output.Id = data.Output.Id;
            gate.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal));
            return gate;
        }
    }
}