using System;

namespace CircuitSimulation.Library
{
    public class InitialSwitchState
    {
        private readonly Guid switchId;
        private readonly bool isOn;

        public InitialSwitchState(Guid switchId, bool isOn)
        {
            this.switchId = switchId;
            this.isOn = isOn;
        }

        public Guid SwitchId
        {
            get { return switchId; }
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