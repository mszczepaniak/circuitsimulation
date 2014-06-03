using System;

namespace CircuitSimulation.Library.Data
{
    public class WireData
    {
        public Guid Id { get; set; }

        public InputData Target { get; set; }

        public OutputData Source { get; set; }
    }
}