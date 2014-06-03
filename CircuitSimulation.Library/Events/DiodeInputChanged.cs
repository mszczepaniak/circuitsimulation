using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class DiodeInputChanged : Event
    {
        private readonly Guid inputId;
        private readonly Signal newSignal;

        public DiodeInputChanged(int time, Diode diode) : base(time)
        {
            inputId = diode.Input.Id;
            newSignal = diode.Input.Signal;
        }

        public override void Process()
        {
            // do nothing
        }

        protected override string Description
        {
            get { return "Diode input changed to " + NewSignal; }
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