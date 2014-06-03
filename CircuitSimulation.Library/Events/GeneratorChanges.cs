using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class GeneratorChanges : Event
    {
        private readonly Generator generator;
        private readonly Signal newSignal;

        public GeneratorChanges(int time, Generator generator) : base(time)
        {
            this.generator = generator;
            newSignal = generator.Output.Signal.Not; // output is still not switched
        }

        public override void Process()
        {
            generator.Process(this);
        }

        protected override string Description
        {
            get { return "Generator changes state to " + newSignal; }
        }
    }
}