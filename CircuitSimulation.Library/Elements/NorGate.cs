namespace CircuitSimulation.Library.Elements
{
    public class NorGate : TwoInputGate
    {
        public NorGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input1.Signal.Nor(Input2.Signal);
        }

        public override string Description
        {
            get { return "Nor gate"; }
        }
    }
}