using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class CircuitControl : UserControl
    {
        private readonly List<CircuitElementControl> elements = new List<CircuitElementControl>();
        private readonly List<WireControl> wires = new List<WireControl>();

        private CircuitElementControl selectedElement;
        public CircuitElementControl SelectedElement
        {
            get { return selectedElement; }
            set
            {
                var oldSelected = selectedElement;
                selectedElement = value;

                // odrysuj na nowo odznaczony i zaznaczony
                if (oldSelected != null)
                    oldSelected.Invalidate(true);
                if (selectedElement != null)
                    selectedElement.Invalidate(true);
            }
        }

        public OutputSocketControl OutputToConnect { get; set; }
        private bool isModified;
        public bool IsModified
        {
            get { return isModified; }
            set
            {
                isModified = value;
                OnModifiedChanged();
            }
        }

        public List<WireControl> Wires
        {
            get { return wires; }
        }

        public List<string> SocketNames
        {
            get
            {
                var results = new List<string>();

                foreach (var element in elements)
                {
                    if (element is FreeSocketControl)
                        results.Add(((FreeSocketControl) element).SocketName);
                }

                return results;
            }
        }

        public CircuitControl()
        {
            InitializeComponent();
        }

        private void CircuitControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void CircuitControl_DragDrop(object sender, DragEventArgs e)
        {
            var itemTag = (string) e.Data.GetData(DataFormats.StringFormat);
            string elementName = null;
            if (ElementRequiresName(itemTag))
            {
                if (!AskForName(out elementName))
                    return;
                SocketNames.Add(Name);
            }

            var element = CreateElementFromTag(itemTag, elementName);
            if (element == null)
                return;
            var position = PointToClient(new Point(e.X, e.Y));

            AddElementControl(element, position.X, position.Y);
            IsModified = true;
        }

        private bool AskForName(out string name)
        {
            return DialogUtils.AskForName(this, "", SocketNames, out name);
        }

        private bool ElementRequiresName(string itemTag)
        {
            return itemTag == "Input" || itemTag == "Output";
        }

        private void AddElementControl(CircuitElementControl element, int x, int y)
        {
            element.Parent = this;
            elements.Add(element);

            element.Left = x;
            element.Top = y;
            Controls.Add(element);
        }

        private CircuitElementControl CreateElementFromTag(string itemTag, string elementName)
        {
            switch (itemTag)
            {
                case "Diode":
                    return new DiodeControl {Designer = this};
                case "Switch":
                    return new SwitchControl {Designer = this};
                case "Buffer":
                    return new BufferControl {Designer = this};
                case "Not":
                    return new NotGateControl {Designer = this};
                case "And":
                    return new AndGateControl {Designer = this};
                case "Or":
                    return new OrGateControl {Designer = this};
                case "Xor":
                    return new XorGateControl {Designer = this};
                case "Nand":
                    return new NandGateControl {Designer = this};
                case "Nor":
                    return new NorGateControl {Designer = this};
                case "Xnor":
                    return new XnorGateControl {Designer = this};
                case "SrLatch":
                    return new SrLatchControl {Designer = this};
                case "Generator":
                    return new GeneratorControl {Designer = this};
                case "IntegratedCircuit":
                    return new IntegratedCircuitControl {Designer = this};
                case "Input":
                    return new FreeInputControl {Designer = this, SocketName = elementName};
                case "Output":
                    return new FreeOutputControl {Designer = this, SocketName = elementName};
                default:
                    return null;
            }
        }

        private void CircuitControl_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedElement = null;
            if (OutputToConnect != null && OutputToConnect.IsSelected)
            {
                OutputToConnect.IsSelected = false;
                if (OutputToConnect.Wires.Count == 0)
                    OutputToConnect.IsConnected = false;
                OutputToConnect.Invalidate(true);
                OutputToConnect = null;
            }
        }

        public CircuitData BuildData()
        {
            var data = new CircuitData();

            foreach (var element in elements)
                data.Elements.Add(element.BuildData());

            foreach (var wire in Wires)
                data.Wires.Add(wire.BuildData());

            return data;
        }

        protected virtual void OnModifiedChanged()
        {
            if (ModifiedChanged != null)
                ModifiedChanged(this, EventArgs.Empty);
        }

        public event EventHandler ModifiedChanged;

        public void SetCircuitData(CircuitData data)
        {
            foreach (var elementData in data.Elements)
            {
                var control = CreateElementControl(elementData);
                AddElementControl(control, elementData.X, elementData.Y);
                control.SetData(elementData);
            }

            foreach (var wire in data.Wires)
            {
                AddWire(wire);
            }
        }

        private CircuitElementControl CreateElementControl(ElementData elementData)
        {
            switch (elementData.Type)
            {
                case ElementType.Diode:
                    return new DiodeControl {Designer = this};
                case ElementType.Switch:
                    return new SwitchControl {Designer = this};
                case ElementType.Buffer:
                    return new BufferControl {Designer = this};
                case ElementType.Not:
                    return new NotGateControl {Designer = this};
                case ElementType.And:
                    return new AndGateControl {Designer = this};
                case ElementType.Or:
                    return new OrGateControl {Designer = this};
                case ElementType.Xor:
                    return new XorGateControl {Designer = this};
                case ElementType.Nand:
                    return new NandGateControl {Designer = this};
                case ElementType.Nor:
                    return new NorGateControl {Designer = this};
                case ElementType.Xnor:
                    return new XorGateControl {Designer = this};
                case ElementType.SrLatch:
                    return new SrLatchControl {Designer = this};
                case ElementType.IntegratedCircuit:
                    return new IntegratedCircuitControl {Designer = this};
                case ElementType.FreeInput:
                    return new FreeInputControl {Designer = this};
                case ElementType.FreeOutput:
                    return new FreeOutputControl {Designer = this};
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddWire(WireData wireData)
        {
            var output = FindOutputControl(wireData.Source.Id);
            var input = FindInputControl(wireData.Target.Id);

            var wire = new WireControl(this, input, output);
            input.Wires.Add(wire);
            output.Wires.Add(wire);
            Wires.Add(wire);
            input.IsConnected = true;
            output.IsConnected = true;
            Controls.Add(wire);
        }

        private OutputSocketControl FindOutputControl(Guid id)
        {
            foreach (var elementControl in elements)
            {
                var output = elementControl.GetOutputById(id);
                if (output != null)
                    return output;
            }
            throw new ApplicationException("Output with id " + id + " not found.");
        }

        private InputSocketControl FindInputControl(Guid id)
        {
            foreach (var elementControl in elements)
            {
                var input = elementControl.GetInputById(id);
                if (input != null)
                    return input;
            }
            throw new ApplicationException("Input with id " + id + " not found.");
        }

        public void DeleteSelectedElement()
        {
            if (SelectedElement == null)
                return;

            elements.Remove(SelectedElement);
            Controls.Remove(SelectedElement);
            RemoveWiresForElement(SelectedElement);
            if (SelectedElement is FreeSocketControl)
            {
                var socket = (FreeSocketControl) SelectedElement;
                SocketNames.Remove(socket.SocketName);
            }

            Invalidate(true);
        }

        private void RemoveWiresForElement(CircuitElementControl control)
        {
            foreach (var input in control.Inputs)
            {
                var wire = FindWireByInputId(input.SocketId);
                Wires.Remove(wire);
                Controls.Remove(wire);
            }

            foreach (var output in control.Outputs)
            {
                var wire = FindWireByOutputId(output.SocketId);
                Wires.Remove(wire);
                Controls.Remove(wire);
            }
        }

        private WireControl FindWireByInputId(Guid id)
        {
            foreach (var wireControl in Wires)
            {
                if (wireControl.Input.SocketId == id)
                    return wireControl;
            }
            return null;
        }

        private WireControl FindWireByOutputId(Guid id)
        {
            foreach (var wireControl in Wires)
            {
                if (wireControl.Output.SocketId == id)
                    return wireControl;
            }
            return null;
        }
    }
}
