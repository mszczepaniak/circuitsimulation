using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class GeneratorData : ElementData
    {
        public OutputData Output { get; set; }
        public GeneratorData()
        {
            Type = ElementType.Generator;
        }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(Output);
            return sockets;
        }
    }
}