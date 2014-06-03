namespace CircuitSimulation.Library.Elements
{
    public class NandGate : TwoInputGate
    {
        public NandGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input1.Signal.Nand(Input2.Signal);
        }

        public override string Description
        {
            get { return "Nand gate"; }
        }
    }
}