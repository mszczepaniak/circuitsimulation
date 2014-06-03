using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class FreeOutputData : ElementData
    {
        public FreeOutputData()
        {
            Type = ElementType.FreeOutput;
        }

        public string Name { get; set; }
        public InputData Input { get; set; }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(Input);
            return sockets;
        }
    }
}