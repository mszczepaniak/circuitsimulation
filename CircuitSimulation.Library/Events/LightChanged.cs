using System;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.Events
{
    public class LightChanged : Event
    {
        private readonly Diode diode;
        private readonly Signal newLight;

        public LightChanged(int time, Diode diode, Signal newLight) : base(time)
        {
            this.diode = diode;
            this.newLight = newLight;
        }

        public override void Process()
        {
            diode.Process(this);
        }

        public bool IsLightOn
        {
            get { return newLight.IsOn; }
        }

        protected override string Description
        {
            get { return "Diode changed light to " + newLight; }
        }

        public Guid DiodeId
        {
            get { return diode.Id; }
        }
    }
}