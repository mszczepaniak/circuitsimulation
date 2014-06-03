namespace CircuitSimulation.Library.Elements
{
    public class Buffer : OneInputGate
    {
        public Buffer(int delay, ISimulation simulation) : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input.Signal;
        }

        public override string Description
        {
            get { return "Buffer"; }
        }
    }
}