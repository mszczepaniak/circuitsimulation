namespace CircuitSimulation.Library.Elements
{
    public class OrGate : TwoInputGate
    {
        public OrGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input1.Signal.Or(Input2.Signal);
        }

        public override string Description
        {
            get { return "Or gate"; }
        }
    }
}