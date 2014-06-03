using System;

namespace CircuitSimulation.Library.Elements
{
    public class FreeInput : Element
    {
        private readonly string name;
        private readonly Input externalInput = new Input();
        private readonly Output output = new Output();

        public FreeInput(int delay, string name, ISimulation simulation) : base(delay, simulation)
        {
            this.name = name;
            externalInput.SignalChanged += () => output.Signal = externalInput.Signal;
        }

        public Output Output
        {
            get { return output; }
        }

        public string Name
        {
            get { return name; }
        }

        public Input ExternalInput
        {
            get { return externalInput; }
        }

        public override Output GetOutputById(Guid outputId)
        {
            if (Output.Id == outputId)
                return Output;

            return null;
        }
    }
}