using System;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public class Generator : Element
    {
        private readonly Output output = new Output();

        public Generator(int delay, ISimulation simulation) : base(delay, simulation)
        {
        }

        public Output Output
        {
            get { return output; }
        }

        public override Output GetOutputById(Guid outputId)
        {
            if (output.Id == outputId)
                return output;

            return null;
        }

        public void Process(GeneratorChanges generatorChanges)
        {
            output.Signal = output.Signal.Not;
            Simulation.AddEvent(new GeneratorChanges(Simulation.CurrentTime + Delay, this));
            Simulation.AddEvent(new GeneratorOutputChanged(Simulation.CurrentTime, this));
        }

        public void Start(Signal initialSignal)
        {
            output.Signal = initialSignal;
            Simulation.AddEvent(new GeneratorChanges(Simulation.CurrentTime + Delay, this));
        }
    }
}