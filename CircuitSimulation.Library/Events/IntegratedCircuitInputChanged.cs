using System;

namespace CircuitSimulation.Library.Events
{
    public class IntegratedCircuitInputChanged : Event
    {
        private readonly Guid inputId;
        private readonly string inputName;
        private readonly Signal newSignal;

        public IntegratedCircuitInputChanged(int time, Guid inputId, string inputName, Signal newSignal) : base(time)
        {
            this.inputId = inputId;
            this.inputName = inputName;
            this.newSignal = newSignal;
        }

        public override void Process()
        {
            // do nothing
        }

        protected override string Description
        {
            get { return "Integrated circuit input " + inputName + " changed signal to " + NewSignal; }
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