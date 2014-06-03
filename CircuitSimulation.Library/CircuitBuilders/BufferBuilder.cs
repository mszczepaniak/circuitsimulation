using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class BufferBuilder : ElementBuilder<Buffer,BufferData>
    {
        protected override Buffer Build(BufferData data, Simulation simulation)
        {
            var buffer = new Buffer(data.Delay, simulation);
            buffer.Id = data.Id;
            buffer.Input.Id = data.Input.Id;
            buffer.Input.SetInitialSocketSignal(Signal.FromSignalType(data.Input.Signal)); 
            buffer.Output.Id = data.Output.Id;
            buffer.Output.SetInitialSocketSignal(Signal.FromSignalType(data.Output.Signal)); 
            return buffer;
        }
    }
}