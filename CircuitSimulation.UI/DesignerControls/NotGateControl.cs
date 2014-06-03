using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class NotGateControl : CircuitElementControl
    {
        public NotGateControl()
        {
            InitializeComponent();
        }

        protected override Image GetImage()
        {
            return Images.notTrans;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            var input = new InputSocketControl(this) { Left = 0, Top = 22 };
            var result = new List<InputSocketControl>();
            result.Add(input);
            return result;
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            var output = new OutputSocketControl(this) { Left = 98, Top = 22 };
            var result = new List<OutputSocketControl>();
            result.Add(output);
            return result;
        }

        public override ElementData BuildData()
        {
            var inputData = Inputs[0].BuildData();
            var outputData = Outputs[0].BuildData();

            return new NotGateData
                       {
                           Delay = this.Delay,
                           Id = ElementId,
                           Input = (InputData) inputData,
                           Output = (OutputData) outputData,
                           X = Left,
                           Y = Top
                       };
        }

        public override void SetData(ElementData elementData)
        {
            var gateData = (NotGateData) elementData;
            ElementId = gateData.Id;
            Inputs[0].SetData(gateData.Input);
            Outputs[0].SetData(gateData.Output);
        }
    }
}
