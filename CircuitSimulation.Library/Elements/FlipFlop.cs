using System;

namespace CircuitSimulation.Library.Elements
{
    public class FlipFlop : Element
    {
        private readonly NorGate resetNorGate;
        private readonly NorGate setNorGate;

        public FlipFlop(int delay, ISimulation simulation)
            : base(delay, simulation)
        {
            setNorGate = new NorGate(delay, simulation);
            resetNorGate = new NorGate(delay, simulation);

            Wire.Connect(setNorGate.Output, resetNorGate.Input1);
            Wire.Connect(resetNorGate.Output, setNorGate.Input2);
        }

        public Input SetInput
        {
            get { return setNorGate.Input1; }
        }

        public Input ResetInput
        {
            get { return resetNorGate.Input2; }
        }

        public Output Output
        {
            get { return setNorGate.Output; }
        }

        public Output NegativeOutput
        {
            get { return resetNorGate.Output; }
        }

        public override Input GetInputById(Guid inputId)
        {
            if (SetInput.Id == inputId)
                return SetInput;
            if (ResetInput.Id == inputId)
                return ResetInput;

            return null;
        }

        public override Output GetOutputById(Guid outputId)
        {
            if (Output.Id == outputId)
                return Output;
            if (NegativeOutput.Id == outputId)
                return NegativeOutput;

            return null;
        }

        public void Initialize()
        {
            setNorGate.Input2.SetInitialSocketSignal(resetNorGate.Output.Signal);
            resetNorGate.Input1.SetInitialSocketSignal(setNorGate.Output.Signal);
        }
    }
}