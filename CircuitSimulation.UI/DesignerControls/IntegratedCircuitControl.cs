using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class IntegratedCircuitControl : CircuitElementControl
    {
        private IntegratedCircuitData integratedCircuitData;
        private string name;

        public IntegratedCircuitControl()
        {
            InitializeComponent();
            Width = Images.integratedCircuitTrans.Width;
            Height = Images.integratedCircuitTrans.Height;
        }

        protected override Image GetImage()
        {
            return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var borderColor = SystemColors.Control;
            var borderDash = DashStyle.Solid;
            if (IsSelected)
            {
                borderColor = Color.Gray;
                borderDash = DashStyle.Dash;
            }
            // narysuj zaznaczenie
            using (var pen = new Pen(borderColor, 1) { DashStyle = borderDash })
            {
                // zaznaczenie jest o jeden piksel węższe i niższe, żeby po odznaczeniu obrazek przykrył ramkę
                var borderRectangle = new Rectangle(0, 0, Width - 2, Height - 2);
                e.Graphics.DrawRectangle(pen, borderRectangle);
            }

            using (var pen = new Pen(Color.Black, 3))
                e.Graphics.DrawRectangle(pen, 8, 8, Width-17, Height-17);

            var nameOnScreen = string.IsNullOrEmpty(name) ? "Double click to open file" : name;
            e.Graphics.DrawString(nameOnScreen, new Font("Consolas", 10), Brushes.Blue, 17, 17);
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            return new List<InputSocketControl>();
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            return new List<OutputSocketControl>();
        }

        public override ElementData BuildData()
        {
            integratedCircuitData.Id = ElementId;
            integratedCircuitData.X = Left;
            integratedCircuitData.Y = Top;
            integratedCircuitData.Name = name;
            return integratedCircuitData;
        }

        public override void SetData(ElementData elementData)
        {
            integratedCircuitData = (IntegratedCircuitData) elementData;
            name = integratedCircuitData.Name;
            ElementId = integratedCircuitData.Id;
            AddInputs(integratedCircuitData.ExternalInputs);
            AddOutputs(integratedCircuitData.ExternalOutputs);
            Invalidate(true);
        }

        private void IntegratedCircuitControl_DoubleClick(object sender, System.EventArgs e)
        {
            string fileName;
            if (!DialogUtils.OpenFile(null, out fileName))
                return;

            var data = ReadData(fileName);
            if (data == null)
            {
                return;
            }

            var elementData = new IntegratedCircuitData();
            elementData.Id = ElementId;
            elementData.Type = ElementType.IntegratedCircuit;
            elementData.Elements = data.Elements;
            elementData.ExternalInputs = ConvertFreeInputs(data.Elements);
            elementData.ExternalOutputs = ConvertFreeOutputs(data.Elements);
            elementData.Wires = data.Wires;
            elementData.Name = Path.GetFileNameWithoutExtension(fileName);

            SetData(elementData);
        }

        private List<InputData> ConvertFreeInputs(List<ElementData> elements)
        {
            var results = new List<InputData>();

            foreach (var elementData in elements)
            {
                if (elementData.Type == ElementType.FreeInput)
                {
                    var freeInput = (FreeInputData) elementData;
                    var input = new InputData
                                    {
                                        Id = elementData.Id,
                                        Name = freeInput.Name
                                    };
                    results.Add(input);
                }
            }
            return results;
        }

        private List<OutputData> ConvertFreeOutputs(List<ElementData> elements)
        {
            var results = new List<OutputData>();

            foreach (var elementData in elements)
            {
                if (elementData.Type == ElementType.FreeOutput)
                {
                    var freeOutput = (FreeOutputData) elementData;
                    var output = new OutputData
                                    {
                                        Id = elementData.Id,
                                        Name = freeOutput.Name
                                    };
                    results.Add(output);
                }
            }
            return results;
        }

        private CircuitData ReadData(string fileName)
        {
            try
            {
                return CircuitDataReader.ReadFromFile(fileName);
            }
            catch(SimulationException e)
            {
                DialogUtils.ShowOpenFileError(null, fileName, e.InnerException.Message);
                return null;
            }
        }

        private void AddInputs(List<InputData> inputs)
        {
            foreach (var inputData in inputs)
            {
                var inputSocketControl = new InputSocketControl(this) {Designer = Designer};
                inputSocketControl.SetData(inputData);
                Inputs.Add(inputSocketControl);
                Controls.Add(inputSocketControl);
            }

            RepositionInputs();
        }

        private void RepositionInputs()
        {
            var inputDistance = Height/(Inputs.Count + 1);
            for (int i = 0; i < Inputs.Count; i++)
            {
                Inputs[i].Left = 2;
                Inputs[i].Top = (i + 1)*inputDistance;
            }
        }

        private void AddOutputs(List<OutputData> outputs)
        {
            foreach (var outputData in outputs)
            {
                var outputSocketControl = new OutputSocketControl(this) {Designer = Designer};
                outputSocketControl.SetData(outputData);
                Outputs.Add(outputSocketControl);
                Controls.Add(outputSocketControl);
            }

            RepositionOutputs();
        }

        private void RepositionOutputs()
        {
            var outputDistance = Height/(Outputs.Count + 1);
            for (int i = 0; i < Outputs.Count; i++)
            {
                Outputs[i].Left = Width - 25;
                Outputs[i].Top = (i + 1)*outputDistance;
            }
        }

        public bool SetSocketState(Guid socketId, SignalType newSignal)
        {
            foreach (var elementData in integratedCircuitData.Elements)
            {
                var sockets = elementData.GetSockets();
                var found = sockets.FirstOrDefault(socket => socket.Id == socketId);
                if (found != null)
                {
                    found.Signal = newSignal;
                    return true;
                }
            }

            return false;
        }
    }
}
