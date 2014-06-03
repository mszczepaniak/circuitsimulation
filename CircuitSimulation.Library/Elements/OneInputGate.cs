using System;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public abstract class OneInputGate : Gate
    {
        private readonly Input input = new Input();

        protected OneInputGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
            input.SignalChanged += InputSignalChanged;
        }

        public Input Input
        {
            get { return input; }
        }

        public void Process(GateInputChanged inputChanged)
        {
            OnInputChanged();
        }

        public override Input GetInputById(Guid inputId)
        {
            if (input.Id == inputId)
                return input;
            return null;
        }

        protected abstract void OnInputChanged();

        private void InputSignalChanged()
        {
            Simulation.AddEvent(new GateInputChanged(Simulation.CurrentTime + Delay, this));
        }
    }
}