using CircuitSimulation.Library.Data;

namespace CircuitSimulation.Library.Elements
{
    public class AndGate : TwoInputGate
    {
        public AndGate(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
        }

        protected override void OnInputChanged()
        {
            Output.Signal = Input1.Signal.And(Input2.Signal);
        }

        public override string Description
        {
            get { return "And gate"; }
        }
    }
}