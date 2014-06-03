using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class IntegratedCircuitData : ElementData
    {
        public string Name { get; set; }
        public List<ElementData> Elements { get; set; }
        public List<WireData> Wires { get; set; }
        public List<InputData> ExternalInputs { get; set; }
        public List<OutputData> ExternalOutputs { get; set; }

        public IntegratedCircuitData()
        {
            Wires = new List<WireData>();
            Elements = new List<ElementData>();
        }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.AddRange(ExternalInputs);
            sockets.AddRange(ExternalOutputs);
            return sockets;
        }
    }
}