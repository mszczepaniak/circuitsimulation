using System;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public class Switch : Element
    {
        private readonly Output output = new Output();

        public Switch(int delay, ISimulation simulation) : base(delay, simulation)
        {
            output.SignalChanged += OnOutputSignalChanged;
        }

        public Output Output
        {
            get { return output; }
        }

        public override Output GetOutputById(Guid outputId)
        {
            if (output.Id == outputId)
                return output;

            return null;
        }

        private void OnOutputSignalChanged()
        {
            Simulation.AddEvent(new SwitchOutputChanged(Simulation.CurrentTime, this));
        }
    }
}