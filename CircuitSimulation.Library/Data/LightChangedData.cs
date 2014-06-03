using System;

namespace CircuitSimulation.Library.Data
{
    public class LightChangedData : EventData
    {
        public Guid DiodeId { get; set; }
        public bool IsLightOn { get; set; }
    }
}