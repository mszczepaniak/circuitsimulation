using System.Collections.Generic;
using System.Xml.Serialization;

namespace CircuitSimulation.Library.Data
{
    [XmlRoot("Circuit")]
    public class CircuitData
    {
        public CircuitData()
        {
            Wires = new List<WireData>();
            Elements = new List<ElementData>();
        }

        public List<ElementData> Elements { get; set; }
        public List<WireData> Wires { get; set; }
    }
}