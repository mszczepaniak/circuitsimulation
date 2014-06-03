using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class GeneratorBuilder : ElementBuilder<Generator, GeneratorData>
    {
        protected override Generator Build(GeneratorData data, Simulation simulation)
        {
            var generator = new Generator(data.Delay, simulation);
            generator.Id = data.Id;
            generator.Output.Id = data.Output.Id;
            generator.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal));
            return generator;
        }
    }

}