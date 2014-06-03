using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class GateData : ElementData
    {
        public GateData()
        {
            Output = new OutputData();
        }

        public OutputData Output { get; set; }
        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(Output);
            return sockets;
        }
    }
}