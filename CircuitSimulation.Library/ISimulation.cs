using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library
{
    public interface ISimulation
    {
        int CurrentTime { get; }
        void AddEvent(Event evnt);
    }
}