namespace CircuitSimulation.Library.Elements
{
    public class XorGate : TwoInputGate
    {
        public XorGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input1.Signal.Exor(Input2.Signal);
        }

        public override string Description
        {
            get { return "Xor gate"; }
        }
    }
}