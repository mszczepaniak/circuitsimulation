using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class FreeInputData : ElementData
    {
        public FreeInputData()
        {
            Type = ElementType.FreeInput;
        }

        public string Name { get; set; }

        public OutputData Output { get; set; }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(Output);
            return sockets;
        }
    }
}