namespace CircuitSimulation.Library.Data
{
    public class OneInputGateData : GateData
    {
        public InputData Input { get; set; }

        public override System.Collections.Generic.List<SocketData> GetSockets()
        {
            var sockets = base.GetSockets();
            sockets.Add(Input);
            return sockets;
        }
    }
}