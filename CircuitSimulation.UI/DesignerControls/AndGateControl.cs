using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class AndGateControl : CircuitElementControl
    {
        public AndGateControl()
        {
            InitializeComponent();
        }

        protected override Image GetImage()
        {
            return Images.andTrans;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            var input1 = new InputSocketControl(this) {Left = 0, Top = 8};
            var input2 = new InputSocketControl(this) {Left = 0, Top = 40};

            var result = new List<InputSocketControl>();
            result.Add(input1);
            result.Add(input2);

            return result;
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            var output = new OutputSocketControl(this) {Left = 98, Top = 24};

            var result = new List<OutputSocketControl>();
            result.Add(output);
            return result;
        }

        public override ElementData BuildData()
        {
            var input1Data = Inputs[0].BuildData();
            var input2Data = Inputs[1].BuildData();
            var outputData = Outputs[0].BuildData();

            return new AndGateData
                       {
                           Delay = this.Delay,
                           Id = ElementId,
                           Input1 = (InputData) input1Data,
                           Input2 = (InputData) input2Data,
                           Output = (OutputData) outputData,
                           X = Left,
                           Y = Top
                       };
        }
        //
        public override void SetData(ElementData elementData)
        {
            var andGateData = (AndGateData) elementData;
            ElementId = andGateData.Id;
            Inputs[0].SetData(andGateData.Input1);
            Inputs[1].SetData(andGateData.Input2);
            Outputs[0].SetData(andGateData.Output);
        }
        
    }
}
