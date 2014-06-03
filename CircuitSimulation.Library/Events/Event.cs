using System;

namespace CircuitSimulation.Library.Events
{
    public abstract class Event
    {
        private readonly int time;

        protected Event(int time)
        {
            if (time < 0)
                throw new ArgumentException("Event time cannot be less than zero!");
            this.time = time;
        }

        public int Time
        {
            get { return time; }
        }

        public abstract void Process();

        public override string ToString()
        {
            return string.Format("{0}: {1}", time, Description);
        }

        protected abstract string Description { get; }
    }
}