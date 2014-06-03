using System;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public abstract class Gate : Element
    {
        private readonly Output output = new Output();

        protected Gate(int delay, ISimulation simulation)
            : base(delay, simulation)
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

        public abstract string Description { get; }

        private void OnOutputSignalChanged()
        {
            Simulation.AddEvent(new GateOutputChanged(Simulation.CurrentTime, this));
        }
    }
}