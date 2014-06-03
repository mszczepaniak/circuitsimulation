namespace CircuitSimulation.Library.Data
{
    public class TwoInputGateData : GateData
    {
        public TwoInputGateData()
        {
            Input2 = new InputData();
            Input1 = new InputData();
        }
        public InputData Input1 { get; set; }
        public InputData Input2 { get; set; }

        public override System.Collections.Generic.List<SocketData> GetSockets()
        {
            var sockets = base.GetSockets();
            sockets.Add(Input1);
            sockets.Add(Input2);
            return sockets;
        }
    }
}