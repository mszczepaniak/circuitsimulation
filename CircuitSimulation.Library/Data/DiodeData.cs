using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class DiodeData : ElementData
    {
        public DiodeData()
        {
            Type = ElementType.Diode;
        }

        public InputData Input { get; set; }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(Input);
            return sockets;
        }
    }
}