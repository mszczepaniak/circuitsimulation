using System;
using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class SimulationData
    {
        public SimulationData()
        {
            Events = new List<EventData>();
        }

        public List<EventData> Events { get; set; }
    }
}