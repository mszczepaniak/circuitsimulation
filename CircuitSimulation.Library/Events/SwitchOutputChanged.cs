
using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class SwitchOutputChanged : Event
    {
        private readonly Guid outputId;
        private readonly Signal newSignal;

        public SwitchOutputChanged(int time, Switch switchElement) : base(time)
        {
            outputId = switchElement.Output.Id;
            newSignal = switchElement.Output.Signal;
        }

        public override void Process()
        {
            // do nothing
        }

        protected override string Description
        {
            get { return "Switch output changed to " + NewSignal; }
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