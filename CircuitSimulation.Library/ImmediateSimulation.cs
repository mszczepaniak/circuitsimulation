using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library
{
    public class ImmediateSimulation : ISimulation
    {
        public int CurrentTime
        {
            get { return 0; }
        }

        public void AddEvent(Event evnt)
        {
            evnt.Process();
        }
    }
}