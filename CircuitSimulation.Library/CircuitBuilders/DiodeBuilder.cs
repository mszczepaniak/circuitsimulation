using System;
using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class DiodeBuilder : ElementBuilder<Diode, DiodeData>
    {
        protected override Diode Build(DiodeData data, Simulation simulation)
        {
            var diode = new Diode(data.Delay, simulation);
            diode.Id = data.Id;
            diode.Input.Id = data.Input.Id;
            diode.Input.SetInitialSocketSignal(Signal.FromSignalType(data.Input.Signal)); 
            return diode;
        }
    }
}