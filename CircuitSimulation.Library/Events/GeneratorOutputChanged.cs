using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class GeneratorOutputChanged : Event
    {
        private readonly Signal newSignal;
        private readonly Guid outputId;

        public GeneratorOutputChanged(int time, Generator generator)
            : base(time)
        {
            outputId = generator.Output.Id;
            newSignal = generator.Output.Signal; 
        }

        public override void Process()
        {
            // do nothing
        }

        protected override string Description
        {
            get { return "Generator output changed to " + NewSignal; }
        }

        public Guid OutputId
        {
            get { return outputId; }
        }

        public Signal NewSignal
        {
            get { return newSignal; }
        }
    }
}