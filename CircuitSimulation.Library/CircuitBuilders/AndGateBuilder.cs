using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class AndGateBuilder : ElementBuilder<AndGate, AndGateData>
    {
        protected override AndGate Build(AndGateData data, Simulation simulation)
        {
            var gate = new AndGate(data.Delay, simulation);
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