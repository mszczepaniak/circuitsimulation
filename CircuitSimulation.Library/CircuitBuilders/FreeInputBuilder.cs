using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class FreeInputBuilder : ElementBuilder<FreeInput, FreeInputData>
    {
        protected override FreeInput Build(FreeInputData data, Simulation simulation)
        {
            var freeInput = new FreeInput(data.Delay, data.Name, simulation);
            freeInput.Id = data.Id;
            freeInput.Output.Id = data.Output.Id;
            freeInput.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal));
            return freeInput;
        }
    }
}