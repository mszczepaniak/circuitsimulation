using System;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public abstract class TwoInputGate : Gate
    {
        private readonly Input input1 = new Input();
        private readonly Input input2 = new Input();

        protected TwoInputGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
            input1.SignalChanged += Input1SignalChanged;
            input2.SignalChanged += Input2SignalChanged;
        }

        public Input Input1
        {
            get { return input1; }
        }

        public Input Input2
        {
            get { return input2; }
        }

        public void Process(GateInput1Changed input1Changed)
        {
            OnInputChanged();
        }

        public void Process(GateInput2Changed input2Changed)
        {
            OnInputChanged();
        }

        public override Input GetInputById(System.Guid inputId)
        {
            if (input1.Id == inputId)
                return input1;
            if (input2.Id == inputId)
                return input2;

            return null;
        }

        protected abstract void OnInputChanged();

        private void Input1SignalChanged()
        {
            Simulation.AddEvent(new GateInput1Changed(Simulation.CurrentTime + Delay, this));
        }

        private void Input2SignalChanged()
        {
            Simulation.AddEvent(new GateInput2Changed(Simulation.CurrentTime + Delay, this));
        }
    }
}