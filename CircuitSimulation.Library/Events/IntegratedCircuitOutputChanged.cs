using System;

namespace CircuitSimulation.Library.Events
{
    public class IntegratedCircuitOutputChanged : Event
    {
        private readonly Guid outputId;
        private readonly string outputName;
        private readonly Signal newSignal;

        public IntegratedCircuitOutputChanged(int time, Guid outputId, string outputName, Signal newSignal) : base(time)
        {
            this.outputId = outputId;
            this.outputName = outputName;
            this.newSignal = newSignal;
        }

        public override void Process()
        {
            // do nothing
        }

        protected override string Description
        {
            get { return "Integrated circuit output " + outputName + " changed signal to " + NewSignal; }
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