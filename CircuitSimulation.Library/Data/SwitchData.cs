using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class SwitchData : ElementData
    {
        public OutputData Output { get; set; }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(Output);
            return sockets;
        }
    }
}