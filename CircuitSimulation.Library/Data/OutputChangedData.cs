using System;

namespace CircuitSimulation.Library.Data
{
    public class OutputChangedData : EventData
    {
        public Guid OutputId { get; set; }
        public SignalType NewSignal { get; set; }
    }
}