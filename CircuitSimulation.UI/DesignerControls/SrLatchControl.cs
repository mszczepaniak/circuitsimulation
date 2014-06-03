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
    public partial class SrLatchControl : CircuitElementControl
    {
        public SrLatchControl()
        {
            InitializeComponent();
        }

        protected override Image GetImage()
        {
            return Images.srLatchTrans;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            var input1 = new InputSocketControl(this) { Left = 0, Top = 8 };
            var input2 = new InputSocketControl(this) { Left = 0, Top = 40 };

            var result = new List<InputSocketControl>();
            result.Add(input1);
            result.Add(input2);

            return result;
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            var output1 = new OutputSocketControl(this) { Left = 98, Top = 8 };
            var output2 = new OutputSocketControl(this) { Left = 98, Top = 40 };

            var result = new List<OutputSocketControl>();
            result.Add(output1);
            result.Add(output2);

            return result;
        }

        public override ElementData BuildData()
        {
            var input1Data = Inputs[0].BuildData();
            var input2Data = Inputs[1].BuildData();
            var output1Data = Outputs[0].BuildData();
            var output2Data = Outputs[1].BuildData();

            return new FlipFlopData
            {
                Delay = this.Delay,
                Id = ElementId,
                SetInput = (InputData) input1Data,
                ResetInput = (InputData) input2Data,
                Output = (OutputData) output1Data,
                NegativeOutput = (OutputData) output2Data,
                X = Left,
                Y = Top
            };
        }

        public override void SetData(ElementData elementData)
        {
            var srLatchData = (FlipFlopData) elementData;
            ElementId = srLatchData.Id;
            Inputs[0].SetData(srLatchData.SetInput);
            Inputs[1].SetData(srLatchData.ResetInput);
            Outputs[0].SetData(srLatchData.Output);
            Outputs[1].SetData(srLatchData.NegativeOutput);
        }
    }
}
