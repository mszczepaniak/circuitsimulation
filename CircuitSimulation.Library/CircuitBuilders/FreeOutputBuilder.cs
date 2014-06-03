using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class FreeOutputBuilder : ElementBuilder<FreeOutput, FreeOutputData>
    {
        protected override FreeOutput Build(FreeOutputData data, Simulation simulation)
        {
            var freeOutput = new FreeOutput(data.Delay, data.Name, simulation);
            freeOutput.Id = data.Id;
            freeOutput.Input.Id = data.Input.Id;
            freeOutput.Input.SetInitialSocketSignal(Signal.FromSignalType(data.Input.Signal));
            return freeOutput;
        }
    }
}