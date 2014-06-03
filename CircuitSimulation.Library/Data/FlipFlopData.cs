using System.Collections.Generic;

namespace CircuitSimulation.Library.Data
{
    public class FlipFlopData : ElementData
    {
        public FlipFlopData()
        {
            Type = ElementType.SrLatch;
        }

        public InputData SetInput { get; set; }

        public InputData ResetInput { get; set; }

        public OutputData Output { get; set; }

        public OutputData NegativeOutput { get; set; }

        public override List<SocketData> GetSockets()
        {
            var sockets = new List<SocketData>();
            sockets.Add(SetInput);
            sockets.Add(ResetInput);
            sockets.Add(Output);
            sockets.Add(NegativeOutput);
            return sockets;
        }
    }
}