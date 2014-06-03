using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class GateOutputChanged : Event
    {
        private readonly Guid outputId;
        private readonly string description;
        private readonly Signal newSignal;

        public GateOutputChanged(int time, Gate gate)
            :base(time)
        {
            outputId = gate.Output.Id;
            newSignal = gate.Output.Signal;
            description = gate.Description;
        }

        public override void Process()
        {
            // do nothing
        }

        protected override string Description
        {
            get { return description + " output changed to " + NewSignal; }
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