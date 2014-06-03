using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library;
using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;
using CircuitSimulation.UI.DesignerControls;

namespace CircuitSimulation.UI
{
    public partial class SimulationControl : UserControl
    {
        private readonly List<CircuitElementControl> elements = new List<CircuitElementControl>();
        private readonly List<WireControl> wires = new List<WireControl>();
        private CircuitData circuitData;

        public SimulationControl()
        {
            InitializeComponent();
        }

        public void SetData(CircuitData data)
        {
            circuitData = data;
            BuildControls();
        }
        
        private void BuildControls()
        {
            foreach (var elementData in circuitData.Elements)
            {
                var elementControl = BuildElement(elementData);
                elementControl.IsSimulation = true;
                elementControl.SetData(elementData);
                elementControl.Left = elementData.X;
                elementControl.Top = elementData.Y;
                elements.Add(elementControl);
                Controls.Add(elementControl);
            }

            foreach (var wireData in circuitData.Wires)
            {
                var wireControl = BuildWire(wireData);
                wireControl.IsSimulation = true;
                wires.Add(wireControl);
                Controls.Add(wireControl);
            }
            Invalidate(true);
        }

        private CircuitElementControl BuildElement(ElementData elementData)
        {
            switch (elementData.Type)
            {
                case ElementType.Diode:
                    return new DiodeControl();
                case ElementType.Switch:
                    return new SwitchControl();
                case ElementType.Buffer:
                    return new BufferControl();
                case ElementType.Not:
                    return new NotGateControl();
                case ElementType.And:
                    return new AndGateControl();
                case ElementType.Or:
                    return new OrGateControl();
                case ElementType.Xor:
                    return new XorGateControl();
                case ElementType.Nand:
                    return new NandGateControl();
                case ElementType.Nor:
                    return new NorGateControl();
                case ElementType.Xnor:
                    return new XnorGateControl();
                case ElementType.SrLatch:
                    return new SrLatchControl();
                case ElementType.Generator:
                    return new GeneratorControl();
                case ElementType.FreeInput:
                    return new FreeInputControl();
                case ElementType.FreeOutput:
                    return new FreeOutputControl();
                case ElementType.IntegratedCircuit:
                    return new IntegratedCircuitControl();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private WireControl BuildWire(WireData wireData)
        {
            var output = FindOutputControl(wireData.Source.Id);
            var input = FindInputControl(wireData.Target.Id);

            output.IsConnected = true;
            input.IsConnected = true;
            
            return new WireControl(this, input, output);
        }
        
        private OutputSocketControl FindOutputControl(Guid id)
        {
            foreach (var elementControl in elements)
            {
                var output = elementControl.GetOutputById(id);
                if (output != null)
                    return output;
            }
            return null;
        }

        private InputSocketControl FindInputControl(Guid id)
        {
            foreach (var elementControl in elements)
            {
                var input = elementControl.GetInputById(id);
                if (input != null)
                    return input;
            }
            return null;
        }

        private CircuitElementControl GetElementById(Guid id)
        {
            foreach (var element in elements)
            {
                if (element.ElementId == id)
                    return element;
            }

            return null;
        }

        public List<InitialSwitchState> GetSwitchStates()
        {
            var results = new List<InitialSwitchState>();
            foreach (var element in elements)
            {
                if (element is SwitchControl)
                {
                    var switchControl = (SwitchControl) element;
                    var switchId = switchControl.ElementId;
                    var isOn = switchControl.IsOn;
                    results.Add(new InitialSwitchState(switchId, isOn));
                }
            }
            return results;
        }
        public List<InitialGeneratorState> GetGeneratorStates()
        {
            var results = new List<InitialGeneratorState>();
            foreach (var element in elements)
            {
                if (element is GeneratorControl)
                {
                    var generatorControl = (GeneratorControl)element;
                    var generatorId = generatorControl.ElementId;
                    var isOn = generatorControl.IsOn;
                    results.Add(new InitialGeneratorState(generatorId, isOn));
                }
            }
            return results;
        }

        public void SetDiodeState(Guid diodeId, bool isLightOn)
        {
            var diode = (DiodeControl) GetElementById(diodeId);
            diode.IsOn = isLightOn;
        }

        public bool SetInputState(Guid inputId, SignalType newSignal)
        {
            var input = FindInputControl(inputId);
            if (input == null) // input not found, so it must be inside some integrated circuit
            {
                foreach (var element in elements)
                {
                    if (element is IntegratedCircuitControl)
                    {
                        var integratedCircuitControl = (IntegratedCircuitControl) element;
                        var found = integratedCircuitControl.SetSocketState(inputId, newSignal);
                        if (found) return true;
                    }
                }
                return false;
            }
            input.Signal = newSignal;
            return true;
        }

        public bool SetOutputState(Guid outputId, SignalType newSignal)
        {
            var output = FindOutputControl(outputId);
            if (output == null) // output not found, so it must be inside some integrated circuit
            {
                foreach (var element in elements)
                {
                    if (element is IntegratedCircuitControl)
                    {
                        var integratedCircuitControl = (IntegratedCircuitControl) element;
                        var found = integratedCircuitControl.SetSocketState(outputId, newSignal);
                        if (found) return true;
                    }
                }

                return false;
            }

            output.Signal = newSignal;
            return true;
        }

        public CircuitData BuildData()
        {
            var data = new CircuitData();

            foreach (var element in elements)
                data.Elements.Add(element.BuildData());

            foreach (var wire in wires)
                data.Wires.Add(wire.BuildData());

            return data;
        }
    }
}
