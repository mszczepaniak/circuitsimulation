namespace CircuitSimulation.Library
{
    public class Input : Socket
    {
        public Input(string name = null)
            : base(name ?? "Input")
        {
        }
    }
}