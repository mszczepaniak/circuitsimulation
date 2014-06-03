namespace CircuitSimulation.Library.Elements
{
    public class NotGate : OneInputGate
    {
        public NotGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input.Signal.Not;
        }

        public override string Description
        {
            get { return "Not gate"; }
        }
    }
}