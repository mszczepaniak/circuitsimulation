using System;

namespace CircuitSimulation.Library.Elements
{
    public class FreeOutput : Element
    {
        private readonly string name;
        private readonly Input input = new Input();
        private readonly Output externalOutput = new Output();

        public FreeOutput(int delay, string name, ISimulation simulation) : base(delay, simulation)
        {
            this.name = name;
            input.SignalChanged += () => externalOutput.Signal = input.Signal;
        }

        public Input Input
        {
            get { return input; }
        }

        public string Name
        {
            get { return name; }
        }

        public Output ExternalOutput
        {
            get { return externalOutput; }
        }

        public override Input GetInputById(Guid inputId)
        {
            if (Input.Id == inputId)
                return Input;

            return null;
        }
    }
}