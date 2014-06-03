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
    public partial class FreeInputControl : FreeSocketControl
    {
        public FreeInputControl()
        {
            InitializeComponent();
        }

        protected override Image GetImage()
        {
            return Images.inputTrans;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            return new List<InputSocketControl>();
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            var output = new OutputSocketControl(this);
            output.Left = 35;
            output.Top = 17;

            var list = new List<OutputSocketControl>();
            list.Add(output);
            return list;
        }

        public override ElementData BuildData()
        {
            return new FreeInputData
                       {
                           Delay = 0,
                           Id = ElementId,
                           X = Left,
                           Y = Top,
                           Output = (OutputData) Outputs[0].BuildData(),
                           Name = SocketName
                       };
        }

        public override void SetData(ElementData elementData)
        {
            var data = (FreeInputData) elementData;
            ElementId = elementData.Id;
            Outputs[0].SetData(data.Output);
        }
    }
}
