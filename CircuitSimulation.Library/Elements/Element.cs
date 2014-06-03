using System;

namespace CircuitSimulation.Library.Elements
{
    public abstract class Element
    {
        private readonly int delay;
        private readonly ISimulation simulation;
        public Guid Id { get; set; }

        protected Element(int delay, ISimulation simulation)
        {
            if (delay < 0)
                throw new ArgumentException("Delay for element cannot be less than zero.");

            if (simulation == null)
                throw new ArgumentNullException("simulation");

            this.delay = delay;
            this.simulation = simulation;
        }

        public int Delay
        {
            get { return delay; }
        }

        protected ISimulation Simulation
        {
            get { return simulation; }
        }

        public virtual Input GetInputById(Guid inputId)
        {
            return null;
        }

        public virtual Output GetOutputById(Guid outputId)
        {
            return null;
        }
    }
}