namespace CircuitSimulation.Library
{
    public class Output : Socket
    {
        public Output(string name = null)
            : base(name ?? "Output")
        {
        }
    }
}