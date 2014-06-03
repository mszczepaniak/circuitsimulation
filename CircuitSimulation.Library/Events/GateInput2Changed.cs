using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class GateInput2Changed : Event
    {
        private readonly TwoInputGate gate;
        private readonly Guid inputId;
        private readonly string description;
        private readonly Signal newSignal;

        public GateInput2Changed(int time, TwoInputGate gate)
            : base(time)
        {
            this.gate = gate;
            inputId = gate.Input2.Id;
            newSignal = gate.Input2.Signal;
            description = gate.Description;
        }

        public override void Process()
        {
            gate.Process(this);
        }

        protected override string Description
        {
            get { return description + " input 2 changed to " + NewSignal; }
        }

        public Guid InputId
        {
            get { return inputId; }
        }

        public Signal NewSignal
        {
            get { return newSignal; }
        }
    }
}