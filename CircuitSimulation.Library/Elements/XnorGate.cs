namespace CircuitSimulation.Library.Elements
{
    public class XnorGate : TwoInputGate
    {
        public XnorGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input1.Signal.Exnor(Input2.Signal);
        }

        public override string Description
        {
            get { return "Xnor gate"; }
        }
    }
}