using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class FlipFlopBuilder : ElementBuilder<FlipFlop, FlipFlopData>
    {
        protected override FlipFlop Build(FlipFlopData data, Simulation simulation)
        {
            var flipFlop = new FlipFlop(data.Delay, simulation);
            flipFlop.Id = data.Id;
            flipFlop.SetInput.Id = data.SetInput.Id;
            flipFlop.SetInput.SetInitialSocketSignal(Signal.FromSignalType(data.SetInput.Signal));
            flipFlop.ResetInput.Id = data.ResetInput.Id;
            flipFlop.ResetInput.SetInitialSocketSignal(Signal.FromSignalType(data.ResetInput.Signal));
            flipFlop.Output.Id = data.Output.Id;
            flipFlop.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal));
            flipFlop.NegativeOutput.Id = data.NegativeOutput.Id;
            flipFlop.NegativeOutput.SetInitialSocketSignal(Signal.FromSignalType(data.NegativeOutput.Signal));
            flipFlop.Initialize();
            return flipFlop;
        }
    }
}