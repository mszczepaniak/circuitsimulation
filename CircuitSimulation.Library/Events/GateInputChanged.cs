using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class GateInputChanged : Event
    {
        private readonly OneInputGate gate;
        private readonly Guid inputId;
        private readonly string description;
        private readonly Signal newSignal;

        public GateInputChanged(int time, OneInputGate gate)
            : base(time)
        {
            this.gate = gate;
            inputId = gate.Input.Id;
            newSignal = gate.Input.Signal;
            description = gate.Description;
        }

        public override void Process()
        {
            gate.Process(this);
        }

        protected override string Description
        {
            get { return description + " input changed to " + NewSignal; }
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