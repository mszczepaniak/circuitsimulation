using System;

namespace CircuitSimulation.Library.Data
{
    public class InputChangedData : EventData
    {
        public Guid InputId { get; set; }
        public SignalType NewSignal { get; set; }
    }
}