using System;

namespace CircuitSimulation.Library
{
    public class InitialGeneratorState
    {
        private readonly Guid generatorId;
        private readonly bool isOn;

        public InitialGeneratorState(Guid generatorId, bool isOn)
        {
            this.generatorId = generatorId;
            this.isOn = isOn;
        }

        public Guid GeneratorId
        {
            get { return generatorId; }
        }

        public Signal InitialSignal
        {
            get
            {
                if (isOn)
                    return Signal.On;
                return Signal.Off;
            }
        }
    }
}