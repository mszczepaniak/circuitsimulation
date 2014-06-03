using System;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public class Diode : Element
    {
        private readonly Input input = new Input();
        private Signal light = Signal.Off;

        public Diode(int delay, ISimulation simulation) : base(delay, simulation)
        {
            input.SignalChanged += InputSignalChanged;
        }

        public Input Input
        {
            get { return input; }
        }

        public Signal Light
        {
            get { return light; }
        }

        public override Input GetInputById(Guid inputId)
        {
            if (input.Id == inputId)
                return input;
            return null;
        }

        public void Process(LightChanged evnt)
        {
            light = evnt.IsLightOn ? Signal.On : Signal.Off;
        }

        private void InputSignalChanged()
        {
            Simulation.AddEvent(new DiodeInputChanged(Simulation.CurrentTime, this));
            Simulation.AddEvent(new LightChanged(Simulation.CurrentTime + Delay, this, Input.Signal));
        }
    }
}